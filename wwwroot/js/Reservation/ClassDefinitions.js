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
        this.tableId = 0;
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