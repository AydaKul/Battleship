public class Cell {
    private bool occupied;
    private Ship ship;

    public Cell() {
        occupied = false;
        ship = null;
    }

    public bool IsOccupied() {
        return occupied;
    }

    public void OccupyCell(Ship ship) {
        occupied = true;
        this.ship = ship;
    }

    public bool Attack() {
        if (occupied) {
            ship.TakeDamage();
            return true;
        }
        return false;
    }
}
