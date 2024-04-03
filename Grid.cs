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
        if (orientation == 0 && x + ship.Length > size || orientation == 1 && y + ship.Length > size) {
            return false; //OUT OF BOUDS
        }
  
        for (int i = 0; i < ship.Length; i++) {
            if (orientation == 0 && IsCellOccupied(x + i, y) || orientation == 1 && IsCellOccupied(x, y + i)) {
                return false; // aLREADY OCCUPIED
            }
        }
  
      if (orientation == 0) {
            for (int i = 0; i < ship.Length; i++) {
                cells[x + i, y].SetShip(ship);
            }
        } 
      
      else {
            for (int i = 0; i < ship.Length; i++) {
                cells[x, y + i].SetShip(ship);
            }
        }
  
        return true;
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
