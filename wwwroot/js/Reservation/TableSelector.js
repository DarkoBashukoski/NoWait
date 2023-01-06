let canvas = document.getElementById('canvas');

$(document).ready(function() {
    canvas.width = $('#canvas-container').innerWidth()-15
    canvas.height = window.innerHeight - 100;
    $('#content-container').height = canvas.height;
    $(window).resize(function () {
        canvas.width = $('#canvas-container').innerWidth()-15
        canvas.height = window.innerHeight - 100;
        $('#content-container').height = canvas.height;
    });
});

let ctx = canvas.getContext("2d");

let isDown = false;
let hasMoved = false;

let offset = new Vector2f(0, 0);
let startPan = new Vector2f(0, 0);
let mouse = new Vector2f(0, 0);
let scale = new Vector2f(1, 1);

let grid = new Vector2f(50, 50);
let tileSize = 30;

let tables = []
let chairs = []
let walls = []

let selectedTable = null;

$.get('/Reservation/GetAllTables', function (data) {
    data.forEach(element => {
        let t = new Table();
        t.position = new Vector2f(element.x, element.y);
        t.size = new Vector2f(element.width, element.height);
        t.tableId = element.tableId;
        tables.push(t);
    });
});


$.get('/Reservation/GetAllChairs', function (data) {
    data.forEach(element => {
        let t = new Chair();
        t.position = new Vector2f(element.x, element.y);
        t.size = new Vector2f(element.width, element.height);
        t.tableId = element.tableId;
        chairs.push(t);
    });
});

$.get('/Reservation/GetAllWalls', function (data) {
    data.forEach(element => {
        let t = new Wall();
        t.position = new Vector2f(element.x, element.y);
        t.size = new Vector2f(element.width, element.height);
        t.tableId = element.tableId;
        walls.push(t);
    });
});

function draw() {
    ctx.fillStyle = "white";
    ctx.fillRect(0, 0, canvas.width, canvas.height);

    drawGrid();

    walls.forEach(element => drawWall(element));
    tables.forEach(element => drawTable(element));
    chairs.forEach(element => drawChair(element));

    if (selectedTable != null) {
        drawBoundingBox(selectedTable);
    }
}

let c = $('canvas')

c.mousedown(function (e) {
    mouse = new Vector2f(
        e.pageX - $(this).offset().left,
        e.pageY - $(this).offset().top
    )

    startPan = mouse.copy();
    isDown = true;
    hasMoved = false;
});

c.mouseup(function () {
    isDown = false;
    if (!hasMoved) {
        let found = false;
        tables.forEach(element => {
            if (contains(element, mouse)) {
                selectedTable = element;
                updateTimeButtons(selectedDateTime, selectedTable.tableId);
                found = true;
            }
        });
    }
});

c.mousemove(function (e) {
    mouse = new Vector2f(
        e.pageX - $(this).offset().left,
        e.pageY - $(this).offset().top
    )
    hasMoved = true;
    if (isDown) {
        let change = Vector2f.subtract(mouse, startPan)
        offset = Vector2f.subtract(offset, Vector2f.divide(change, scale))

        startPan = mouse.copy();
    }
    draw()
});

canvas.addEventListener('wheel', function (e) {
    e.preventDefault();
    mouse = new Vector2f(
        e.pageX - $(this).offset().left,
        e.pageY - $(this).offset().top
    )

    let beforeZoom = screenToWorld(mouse);
    if (e.deltaY > 0) {
        scale = Vector2f.subtract(scale, new Vector2f(0.1, 0.1));
    } else {
        scale = Vector2f.add(scale, new Vector2f(0.1, 0.1));
    }
    if(scale.x < 0.30000000000000004 || scale.y < 0.30000000000000004) {
        scale.x = 0.30000000000000004
        scale.y = 0.30000000000000004
    }
    if(scale.x > 1.3 || scale.y > 1.3) {
        scale.x = 1.3
        scale.y = 1.3
    }
    console.log(scale)
    let afterZoom = screenToWorld(mouse);
    offset = Vector2f.add(Vector2f.subtract(beforeZoom, afterZoom), offset);

    draw();
});

function worldToScreen(worldCoords) {
    return Vector2f.multiply(scale, Vector2f.subtract(worldCoords, offset)).round();
}

function screenToWorld(screenCoords) {
    return Vector2f.add(Vector2f.divide(screenCoords, scale), offset);
}

function drawWall(wall) {
    ctx.strokeStyle = '#686868';
    ctx.fillStyle = 'rgba(136, 136, 136, 0.7)'
    ctx.lineWidth = 1 * scale.x;

    let start = worldToScreen(new Vector2f(wall.position.x * tileSize, wall.position.y * tileSize));
    let size = Vector2f.multiply(new Vector2f(tileSize * wall.size.x, tileSize * wall.size.y), scale);

    ctx.beginPath();
    ctx.rect(start.x, start.y, size.x, size.y);
    ctx.fill();
    ctx.stroke();
}

function drawChair(chair) {
    ctx.strokeStyle = '#32230b';
    ctx.fillStyle = 'rgba(67, 42, 4, 0.7)';
    ctx.lineWidth = 1 * scale.x;

    let start = worldToScreen(new Vector2f(chair.position.x * tileSize, chair.position.y * tileSize));
    let size = Vector2f.multiply(new Vector2f(tileSize * chair.size.x, tileSize * chair.size.y), scale);

    ctx.beginPath();
    ctx.rect(start.x, start.y, size.x, size.y);
    ctx.fill();
    ctx.stroke();
}

function drawTable(table) {
    ctx.strokeStyle = '#694d23';
    ctx.fillStyle = 'rgba(150, 111, 51, 0.7)';
    ctx.lineWidth = 1 * scale.x;

    let start = worldToScreen(new Vector2f(table.position.x * tileSize, table.position.y * tileSize));
    let size = Vector2f.multiply(new Vector2f(tileSize * table.size.x, tileSize * table.size.y), scale);

    ctx.beginPath();
    ctx.rect(start.x, start.y, size.x, size.y);
    ctx.fill();

    ctx.fillStyle = 'white';
    ctx.textAlign = 'center';
    ctx.textBaseline = 'middle'
    ctx.font = `${scale.x * 36}px serif`;
    ctx.fillText(table.tableId, start.x + size.x/2, start.y + size.y/2);
    
    ctx.stroke();
}

function drawBoundingBox(r) {
    ctx.strokeStyle = 'aqua';
    ctx.fillStyle = 'white';
    ctx.lineWidth = 1 * scale.x;

    let start = worldToScreen(new Vector2f(r.position.x * tileSize, r.position.y * tileSize));
    let size = Vector2f.multiply(new Vector2f(tileSize * r.size.x, tileSize * r.size.y), scale);

    ctx.beginPath();
    ctx.rect(start.x, start.y, size.x, size.y);
    ctx.stroke();

    let xDist = size.x / 2;
    let yDist = size.y / 2;

    for (let i = 0; i < 3; i++) {
        for (let j = 0; j < 3; j++) {
            if (i === 1 && j === 1) {
                continue;
            }
            ctx.beginPath();
            ctx.rect(start.x + xDist * i - 5, start.y + yDist * j - 5, 11, 11);
            ctx.fill();
            ctx.stroke();
        }
    }
}

function drawGrid() {
    for (let i = 0; i < grid.x; i += 2) {
        for (let j = 0; j < grid.y; j += 2) {
            let start = worldToScreen(new Vector2f(i * tileSize, j * tileSize));
            let size = Vector2f.multiply(new Vector2f(tileSize * 2, tileSize * 2), scale);

            ctx.strokeStyle = '#ebebeb';
            ctx.lineWidth = 1;

            ctx.beginPath();
            ctx.rect(start.x, start.y, size.x, size.y);
            ctx.stroke();
        }
    }
}

function contains(worldRect, screenPoint) {
    let start = worldToScreen(new Vector2f(worldRect.position.x * tileSize, worldRect.position.y * tileSize));
    let size = Vector2f.multiply(new Vector2f(tileSize * worldRect.size.x, tileSize * worldRect.size.y), scale);

    return start.x <= screenPoint.x && screenPoint.x <= start.x + size.x &&
        start.y <= screenPoint.y && screenPoint.y <= start.y + size.y
}

draw();

$(document).ready(draw);
$(document).resize(draw);