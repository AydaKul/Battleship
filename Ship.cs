public class Ship {
    private int size;
    private int health;

    public Ship(int size) {
        this.size = size;
        health = size;
    }

    public void TakeDamage() {
        health--;
    }

    public bool IsSunk() {
        return health <= 0;
    }
}
