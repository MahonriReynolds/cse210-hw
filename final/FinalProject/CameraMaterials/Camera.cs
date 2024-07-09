

public class Camera
{
    private Frame _frame1;
    private Frame _frame2;

    public Camera(int viewWidth, int viewHeight)
    {
        this._frame1 = new Frame(viewWidth, viewHeight);
        this._frame2 = new Frame(viewWidth, viewHeight);
    }

    public void MakeNextFrame(char[,] content)
    {
        this._frame2.Fill(content);
    }

    public void Display()
    {
        char[,] frame1Data = this._frame1.GetContent();
        char[,] frame2Data = this._frame2.GetContent();

        int height = frame1Data.GetLength(0);
        int width = frame1Data.GetLength(1);

        Console.CursorVisible = false;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (frame1Data[i, j] != frame2Data[i, j])
                {
                    this._frame1.UpdateCell(i, j, frame2Data[i, j]);
                    Console.SetCursorPosition(i, j);
                    Console.Write(frame2Data[i, j]);
                }
            } 
        }
        Console.SetCursorPosition(0, height);
    }
}



