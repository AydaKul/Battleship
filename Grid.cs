public class Grid {
    private int size;
    private Cell[,] cells;
    private Random random;
    
    public Grid(int size) {
        this.size = size;
        cells = new Cell[size, size];
        random = new Random();
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
            return false; //OUT OF BOUNDS
        }
  
        for (int i = 0; i < ship.Length; i++) {
            if (orientation == 0 && IsCellOccupied(x + i, y) || orientation == 1 && IsCellOccupied(x, y + i)) {
                return false; // ALREADY OCCUPIED
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

    public void PlaceRandomizedShips() {
        PlaceRandomizedShip(5);
        PlaceRandomizedShip(4);
        PlaceRandomizedShip(3);
        PlaceRandomizedShip(3);
        PlaceRandomizedShip(2);

    private void PlaceRandomizedShip(int shipSize) {
        bool placed = false;
        
        while (!placed) {
            int x = random.Next(size);
            int y = random.Next(size);
            int orientation = random.Next(2);

            if (PlaceShip(new Ship(shipSize), x, y, orientation)) {
                placed = true;
            }
        }
    }

    public void RandomAttack(Grid opponentGrid) {
        int x = random.Next(size);
        int y = random.Next(size);
        opponentGrid.AttackCell(x, y);
    }
}
