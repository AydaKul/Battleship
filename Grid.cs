public class Grid {
    private int size;
    private Cell[,] cells;

    public Grid(int size) {
        this.size = size;
        cells = new Cell[size, size];
    }

    public void SetupGrid() { //ChatGPT helped with this
        for (int i = 0; i < size; i++) {
            for (int j = 0; j < size; j++) {
                cells[i, j] = new Cell();
            }
        }
    }

        public bool PlaceShip(Ship ship, int x, int y, int orientation) {
            return false; // Placeholder until I add this code
        }

    public bool IsCellOccupied(int x, int y) {
        return cells[x, y].IsOccupied();
    }

    public bool AttackCell(int x, int y) {
        return cells[x, y].Attack();
    }

    public bool IsShipSunk(Ship ship) {
        return ship.IsSunk();
    }
}
