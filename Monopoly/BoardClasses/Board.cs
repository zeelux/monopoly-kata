using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly.BoardClasses
{
    public class Board
    {
        List<BoardSquare> squares;

        public Board()
        {
            squares = new List<BoardSquare>();

            squares.Add(new GoSquare());

            squares.Add(new PropertySquare("Mediterranean Avenue", 60, OwnableSquare.PropertyGroup.Purple, new int[] {2,10,30,90,160,250}));
            squares.Add(new BoardSquare("Community Chest"));
            squares.Add(new PropertySquare("Baltic Avenue", 60, OwnableSquare.PropertyGroup.Purple, new int[] {4,20,60,180,320,450}));
            squares.Add(new IncomeTaxSquare());
            squares.Add(new RailRoadSquare("Reading Railroad"));
            squares.Add(new PropertySquare("Oriental Avenue", 100, OwnableSquare.PropertyGroup.Light_Blue, new int[] {6,30,90,270,400,550}));
            squares.Add(new BoardSquare("Chance"));
            squares.Add(new PropertySquare("Vermont Avenue", 100, OwnableSquare.PropertyGroup.Light_Blue, new int[] { 6, 30, 90, 270, 400, 550 }));
            squares.Add(new PropertySquare("Connecticut Avenue", 120, OwnableSquare.PropertyGroup.Light_Blue, new int[] { 8, 40, 100, 300, 450, 600 }));

            squares.Add(new JustVisitingSquare());

            squares.Add(new PropertySquare("St. Charles Place", 140, OwnableSquare.PropertyGroup.Light_Purple, new int[] {10,50,150,450,625,750}));
            squares.Add(new UtilitySquare("Electric", 150, OwnableSquare.PropertyGroup.Utility));
            squares.Add(new PropertySquare("States Avenue", 140, OwnableSquare.PropertyGroup.Light_Purple, new int[] { 10, 50, 150, 450, 625, 750 }));
            squares.Add(new PropertySquare("Virginia Avenue", 160, OwnableSquare.PropertyGroup.Light_Purple, new int[] { 12, 60, 180, 500, 700, 900 }));
            squares.Add(new RailRoadSquare("Pennsylvania"));
            squares.Add(new PropertySquare("St. James Avenue", 180, OwnableSquare.PropertyGroup.Orange, new int[] {14,70,200,550,750,950}));
            squares.Add(new BoardSquare("Community Chest"));
            squares.Add(new PropertySquare("Tennesse Avenue", 180, OwnableSquare.PropertyGroup.Orange, new int[] { 14, 70, 200, 550, 750, 950 }));
            squares.Add(new PropertySquare("New York Avenue", 200, OwnableSquare.PropertyGroup.Orange, new int[] { 16, 80, 220, 600, 800, 1000 }));

            squares.Add(new BoardSquare("Free Parking"));

            squares.Add(new PropertySquare("Kentucky Avenue", 220, OwnableSquare.PropertyGroup.Red, new int[] {18,90,250,700,875,1050}));
            squares.Add(new BoardSquare("Chance"));
            squares.Add(new PropertySquare("Indiana Avenue", 220, OwnableSquare.PropertyGroup.Red, new int[] { 18, 90, 250, 700, 875, 1050 }));
            squares.Add(new PropertySquare("Illinios Avenue", 240, OwnableSquare.PropertyGroup.Red, new int[] { 20, 100, 300, 750, 925, 1100 }));
            squares.Add(new RailRoadSquare("B&O Railroad"));
            squares.Add(new PropertySquare("Atlantic Avenue", 260, OwnableSquare.PropertyGroup.Yellow, new int[] { 22, 110, 330, 800, 975, 1150 }));
            squares.Add(new PropertySquare("Ventnor Avenue", 260, OwnableSquare.PropertyGroup.Yellow, new int[] {22,110,330,800,975,1150}));
            squares.Add(new UtilitySquare("Water Works", 150, OwnableSquare.PropertyGroup.Utility));
            squares.Add(new PropertySquare("Marvin Gardens", 280, OwnableSquare.PropertyGroup.Yellow, new int[] {24,120,360,850,1025,1200}));            

            squares.Add(new GoToJailSquare());

            squares.Add(new PropertySquare("Pacific Avenue", 300, OwnableSquare.PropertyGroup.Green, new int[] {26,130,390,900,1100,1275}));
            squares.Add(new PropertySquare("North Carolina Avenue", 300, OwnableSquare.PropertyGroup.Green, new int[] { 26, 130, 390, 900, 1100, 1275 }));
            squares.Add(new BoardSquare("Community Chest"));
            squares.Add(new PropertySquare("Pennsylvania Avenue", 320, OwnableSquare.PropertyGroup.Green, new int[] { 28, 150, 450, 1000, 1200, 1400 }));
            squares.Add(new RailRoadSquare("Short Line Railroad"));
            squares.Add(new BoardSquare("Chance"));
            squares.Add(new PropertySquare("Park Place", 350, OwnableSquare.PropertyGroup.Dark_Blue, new int[] {35,175,500,1100,1300,1500}));            
            squares.Add(new LuxuryTaxSquare());
            squares.Add(new PropertySquare("Boardwalk", 400, OwnableSquare.PropertyGroup.Dark_Blue, new int[] {50,200,600,1400,1700,2000}));
        }

        public int NumberOfSquares
        {
            get { return this.squares.Count; }
        }
        public BoardSquare GetSquareAtPosition(int position)
        {
            return squares[position];
        }

        public List<BoardSquare> GetAllBoardSquaresInGroup(OwnableSquare.PropertyGroup group)
        {
            return this.squares.FindAll(delegate(BoardSquare square)
            {
                return (square is OwnableSquare && ((OwnableSquare)square).Group == group);
            });
        }
    }
}
