using Raylib_cs;
using ImGuiNET;
using System;

namespace ML
{

       
    class Program
    {
        const int screenWidth = 800;
        const int screenHeight = 800;


        public static void Main()
        {

            int numberOfLED = 0;

            int a = 0;

            Raylib.InitWindow(screenWidth, screenHeight, "Ray Simluation");

            ImguiController.ImguiController controller = new();

            controller.Load(screenWidth, screenHeight);            
            ImGui.SetNextWindowPos(new System.Numerics.Vector2((int)(screenWidth*0.5), 0));
            ImGui.SetNextWindowSize(new System.Numerics.Vector2((int)(screenWidth * 0.5), (int)(-screenHeight * 0.4)));

            while (!Raylib.WindowShouldClose())
            {

                float dt = Raylib.GetFrameTime();

                Raylib.BeginDrawing();

                Raylib.ClearBackground(Color.GRAY);



                Raylib.DrawLine((int)Raylib.GetMousePosition().X,(int)Raylib.GetMousePosition().Y, 200,200, Color.RED);

                DrawHelper.DrawRay((int)Raylib.GetMousePosition().X,(int)Raylib.GetMousePosition().Y);

                Radiate.Radiate.drawthis(numberOfLED, 100, Color.GREEN);

                for (int i = 0; i < numberOfLED; i++)
                {
                    Radiate.Radiate.drawthis(i*10, 100, Color.RED);
                }


                if (Raylib.IsMouseButtonPressed(0))
                {
                    a++;
                    Radiate.Radiate.intList.Add(a);

                    for (int i = 0; i < Radiate.Radiate.intList.Count; i++)
                    {
                        Console.WriteLine(Radiate.Radiate.intList[i].ToString());
                    }

                }

                //controller update
                controller.Update(dt);


                ImGui.Begin("Simulation Settings");
                ImGui.Text("Set number of LEDS");
                ImGui.SliderInt("", ref numberOfLED, 0, 360);
                ImGui.End();

                controller.Draw();

                Raylib.DrawText(Raylib.GetFPS().ToString(), 12, 12, 20, Color.BLACK);
                Raylib.EndDrawing();
            }

            controller.Dispose();
            Raylib.CloseWindow();
        }

    }

    class DrawHelper 
    {
            public static void DrawRay(int x,int y)
            {
            int length = 500;
                for (int i = 0; i < 360; i++)
                {
                Raylib.DrawLine(x, y, x + (int)(length * Math.Sin(i * (Math.PI/180))), y + (int)(length * Math.Cos(i * (Math.PI/180))), Color.GREEN);

                }

                return;
            }
    }
}

