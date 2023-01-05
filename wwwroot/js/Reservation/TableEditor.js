class Vector2f {
    constructor(x, y) {
        this.x = x;
        this.y = y;
    }

    static add(vec1, vec2) {
        return new Vector2f(vec1.x + vec2.x, vec1.y + vec2.y)
    }

    static subtract(vec1, vec2) {
        return new Vector2f(vec1.x - vec2.x, vec1.y - vec2.y)
    }

    static multiply(vec1, vec2) {
        return new Vector2f(vec1.x * vec2.x, vec1.y * vec2.y);
    }

    static divide(vec1, vec2) {
        return new Vector2f(vec1.x / vec2.x, vec1.y / vec2.y)
    }

    static scalarMultiply(scalar, vec1) {
        return new Vector2f(scalar * vec1.x, scalar * vec1.y);
    }

    copy() {
        return new Vector2f(this.x, this.y);
    }

    round() {
        return new Vector2f(Math.round(this.x), Math.round(this.y));
    }
}

class Chair {
    constructor() {
        this.position = new Vector2f(0, 0);
        this.size = new Vector2f(2, 2);
    }
}

class Table {
    constructor() {
        this.position = new Vector2f(0, 0);
        this.size = new Vector2f(6, 4);
    }
}

class Wall {
    constructor() {
        this.position = new Vector2f(0, 0)
        this.size = new Vector2f(4, 4);
    }
}

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

let movingObject = false;
let moveMouseStart = new Vector2f(0, 0);
let moveObjectStart = new Vector2f(0, 0);

let scalingObject = false;
let scaleMouseStart = new Vector2f(0, 0);
let scalingType = "";
let scalePositionStart = new Vector2f(0, 0);
let scaleSizeStart = new Vector2f(0, 0);

let offset = new Vector2f(0, 0);
let startPan = new Vector2f(0, 0);
let mouse = new Vector2f(0, 0);
let scale = new Vector2f(1, 1);

let grid = new Vector2f(50, 50);
let tileSize = 30;

let tables = []
let chairs = []
let walls = []

let selected = null;

let wall = new Wall()
wall.position.x = 3;
wall.position.y = 6;
walls.push(wall);

let chair = new Chair();
chair.position.x = 9;
chair.position.y = 9;
chairs.push(chair);

let table = new Table();
table.position.x = 8;
table.position.y = 3;
tables.push(table);

function draw() {
    ctx.fillStyle = "white";
    ctx.fillRect(0, 0, canvas.width, canvas.height);

    drawGrid();

    walls.forEach(element => drawWall(element));
    tables.forEach(element => drawTable(element));
    chairs.forEach(element => drawChair(element));

    if (selected != null) {
        drawBoundingBox(selected);
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
    if (selected != null && isScaling(selected, mouse)) {
        scalingObject = true;
        scaleMouseStart = mouse.copy();
        scalePositionStart = selected.position.copy();
        scaleSizeStart = selected.size.copy();
        return;
    }
    if (selected != null && contains(selected, mouse)) {
        movingObject = true;
        moveMouseStart = mouse.copy();
        moveObjectStart = selected.position.copy();
    } else {
        movingObject = false;
    }
});

c.mouseup(function (e) {
    isDown = false;
    movingObject = false;
    scalingObject = false;
    if (!hasMoved) {
        let found = false;
        tables.concat(walls, chairs).forEach(element => {
            if (contains(element, mouse)) {
                selected = element;
                found = true;
            }
        });
        if (!found) {
            selected = null;
        }
    }
});

c.mousemove(function (e) {
    mouse = new Vector2f(
        e.pageX - $(this).offset().left,
        e.pageY - $(this).offset().top
    )
    hasMoved = true;
    if (isDown) {
        if (scalingObject) {
            let change = Vector2f.divide(Vector2f.subtract(mouse, scaleMouseStart), scale);
            let normalized = Vector2f.divide(change, new Vector2f(tileSize, tileSize));
            scaleObject(normalized);
        } else if (movingObject) {
            let change = Vector2f.divide(Vector2f.subtract(mouse, moveMouseStart), scale);
            let normalized = Vector2f.divide(change, new Vector2f(tileSize, tileSize));
            selected.position = Vector2f.add(moveObjectStart, normalized).round();
        } else {
            let change = Vector2f.subtract(mouse, startPan)
            offset = Vector2f.subtract(offset, Vector2f.divide(change, scale))

            startPan = mouse.copy();
        }
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

function isScaling(worldRect, mousePoint) {
    let start = worldToScreen(new Vector2f(worldRect.position.x * tileSize, worldRect.position.y * tileSize));
    let size = Vector2f.multiply(new Vector2f(tileSize * worldRect.size.x, tileSize * worldRect.size.y), scale);

    let xDist = size.x / 2;
    let yDist = size.y / 2;

    for (let i = 0; i < 3; i++) {
        for (let j = 0; j < 3; j++) {
            if (i === 1 && j === 1) {
                continue;
            }
            let pos = new Vector2f(start.x + xDist * i - 5, start.y + yDist * j - 5)
            let scale = new Vector2f(11, 11)

            if (pos.x <= mousePoint.x && mousePoint.x <= pos.x + scale.x && pos.y <= mousePoint.y && mousePoint.y <= pos.y + scale.y) {
                scalingType = getScalingType(i, j);
                return true;
            }
        }
    }
    return false;
}

function getScalingType(x, y) {
    switch(3*x + y) {
        case 0: return "top-left";
        case 1: return "left";
        case 2: return "bottom-left";
        case 3: return "top";
        case 5: return "bottom";
        case 6: return "top-right";
        case 7: return "right";
        case 8: return "bottom-right";
        default: return "";
    }
}

function scaleObject(change) {
    switch(scalingType) {
        case "top-left":
            selected.size = Vector2f.subtract(scaleSizeStart, change).round();
            selected.position = Vector2f.subtract(scalePositionStart, Vector2f.subtract(selected.size, scaleSizeStart)).round();
            break;
        case "left":
            selected.size.x = Vector2f.subtract(scaleSizeStart, change).round().x;
            selected.position.x = Vector2f.subtract(scalePositionStart, Vector2f.subtract(selected.size, scaleSizeStart)).round().x;
            break;
        case "bottom-left":
            selected.size.x = Vector2f.subtract(scaleSizeStart, change).round().x;
            selected.position.x = Vector2f.subtract(scalePositionStart, Vector2f.subtract(selected.size, scaleSizeStart)).round().x;
            selected.size.y = Vector2f.add(scaleSizeStart, change).round().y;
            break;
        case "top":
            selected.size.y = Vector2f.subtract(scaleSizeStart, change).round().y;
            selected.position.y = Vector2f.subtract(scalePositionStart, Vector2f.subtract(selected.size, scaleSizeStart)).round().y;
            break;
        case "bottom":
            selected.size.y = Vector2f.add(scaleSizeStart, change).round().y;
            break;
        case "top-right":
            selected.size.y = Vector2f.subtract(scaleSizeStart, change).round().y;
            selected.position.y = Vector2f.subtract(scalePositionStart, Vector2f.subtract(selected.size, scaleSizeStart)).round().y;
            selected.size.x = Vector2f.add(scaleSizeStart, change).round().x;
            break;
        case "right":
            selected.size.x = Vector2f.add(scaleSizeStart, change).round().x;
            break;
        case "bottom-right":
            selected.size = Vector2f.add(scaleSizeStart, change).round();
    }
}

function addTable() {
    tables.push(new Table());
}

function addChair() {
    chairs.push(new Chair());
}

function addWall() {
    walls.push(new Wall());
}

draw();

$(document).ready(draw);
$(document).resize(draw);