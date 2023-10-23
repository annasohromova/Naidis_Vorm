using System;
using System.Collections.Generic;
using System.Drawing; // Подключение пространства имен для Point класса
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jalgpall;


internal class Walls
{
    List<Figure> wallList;

    public Walls(int mapWidth, int mapHeight)
    {
        wallList = new List<Figure>();

        // Создаем верхнюю горизонтальную линию
        HorizontalLine topLine = new HorizontalLine(0, mapWidth - 1, 0, '*');
        // Создаем нижнюю горизонтальную линию
        HorizontalLine bottomLine = new HorizontalLine(0, mapWidth - 1, mapHeight - 1, '*');
        // Создаем левую вертикальную линию
        VerticalLine leftLine = new VerticalLine(0, mapHeight - 1, 0, '*');
        // Создаем правую вертикальную линию
        VerticalLine rightLine = new VerticalLine(0, mapHeight - 1, mapWidth - 1, '*');

        wallList.Add(topLine);
        wallList.Add(bottomLine);
        wallList.Add(leftLine);
        wallList.Add(rightLine);
    }

    internal bool IsHit(Figure figure)
    {
        foreach (var wall in wallList)
        {
            if (wall.IsHit(figure))
            {
                return true;
            }
        }
        return false;
    }

    public void Draw()
    {
        foreach (var wall in wallList)
        {
            wall.Draw();
        }
    }
}