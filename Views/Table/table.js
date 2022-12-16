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
}

let canvas = document.getElementById('canvas');
let ctx = canvas.getContext("2d");

let isDown = false;

let offset = new Vector2f(0, 0);
let startPan = new Vector2f(0, 0);
let mouse = new Vector2f(0, 0);
let scale = new Vector2f(1, 1);

draw();

function draw() {
    ctx.clearRect(0, 0, canvas.width, canvas.height);

    for (let i=0; i<51; i+=5) {
        let start = new Vector2f(0, i);
        let end = new Vector2f(50, i);

        ctx.strokeStyle = 'black';
        ctx.lineWidth = 1;

        ctx.beginPath();
        ctx.moveTo(worldToScreen(start).x, worldToScreen(start).y);
        ctx.lineTo(worldToScreen(end).x, worldToScreen(end).y);
        ctx.stroke();
    }

    for (let i=0; i<51; i+=5) {
        let start = new Vector2f(i, 0);
        let end = new Vector2f(i, 50);

        ctx.strokeStyle = 'black';
        ctx.lineWidth = 1;

        ctx.beginPath();
        ctx.moveTo(worldToScreen(start).x, worldToScreen(start).y);
        ctx.lineTo(worldToScreen(end).x, worldToScreen(end).y);
        ctx.stroke();
    }
}

let c = $('canvas')

c.mousedown(function (e) {
    startPan.x = e.pageX - $(this).offset().left;
    startPan.y = e.pageY - $(this).offset().top;
    isDown = true;
});

c.mouseup(function (e) {
    isDown = false;
});

c.mousemove(function (e) {
    mouse = new Vector2f(
        e.pageX - $(this).offset().left,
        e.pageY - $(this).offset().top
    )
    if (isDown) {
        let change = Vector2f.subtract(mouse, startPan)
        offset = Vector2f.subtract(offset, change)

        startPan = mouse.copy();
        draw()
    }
});

canvas.addEventListener('wheel', function (e) {
    if (e.deltaY > 0) {
        scale = Vector2f.scalarMultiply(0.999, scale);
    } else {
        scale = Vector2f.subtract(1.001, scale);
    }
});

function worldToScreen(worldCoords) {
    return Vector2f.multiply(scale, Vector2f.subtract(worldCoords, offset));
}

function screenToWorld(screenCoords) {
    return Vector2f.add(Vector2f.divide(screenCoords, scale), offset);
}

class Chair {
    constructor() {
        const fill = 'rgba(67, 42, 4, 0.7)'
        const stroke = '#32230b'
        const shadow = 'rgba(0, 0, 0, 0.4) 3px 3px 7px'
    }
}

class Table {
    constructor() {
        const fill = 'rgba(150, 111, 51, 0.7)'
        const stroke = '#694d23'
        const shadow = 'rgba(0, 0, 0, 0.4) 3px 3px 7px'
    }
}

class Wall {
    constructor() {
        const fFill = 'rgba(136, 136, 136, 0.7)'
        const stroke = '#686868'
        const shadow = 'rgba(0, 0, 0, 0.4) 5px 5px 20px'
    }
}