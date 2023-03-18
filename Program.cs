using Raylib_cs;
using ImGuiNET;
using System;

namespace ML
{

       
    class Program
    {
        const int screenWidth = 1200;
        const int screenHeight = 800;


        public static void Main()
        {

            int numberOfLED = 1;

            int numberOfSensors = 1;

            int Radius = 100;

            bool circleSelect = true;
            bool squareSelect = false;

            bool drawRays = false;

            float offset = 0;


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





                //Raylib.DrawLine((int)Raylib.GetMousePosition().X,(int)Raylib.GetMousePosition().Y, 200,200, Color.RED);

                //DrawHelper.DrawRay((int)Raylib.GetMousePosition().X,(int)Raylib.GetMousePosition().Y);

                //Radiate.Radiate.drawthis(numberOfLED, 100, Color.GREEN);

                Raylib.DrawCircleLines((int)screenWidth / 2, (int)screenHeight / 2, Radius, Color.GREEN);

                for (int k = 0; k < numberOfSensors; k++)
                {


                    float angle = (float)((((float)(k + 1) / (numberOfSensors)))* 2 * Math.PI);


                    Raylib.DrawCircle((int)(screenWidth/2 +(Radius * Math.Sin(angle))),(int)(screenHeight/2 + (Radius * Math.Cos(angle))),5, Color.BLACK);
                    

                  if(drawRays)
                    {
                        for (int j = 0; j < numberOfLED; j++)
                        {
                            float Circleangle = (float)((((float)(j + 1) / (numberOfLED))) * 2 * Math.PI);

                            Circleangle += offset * (float)(Math.PI / 180);

                            int x = (int)(screenWidth / 2 + (Radius * Math.Sin(Circleangle)));
                            int y = (int)(screenHeight / 2 + (Radius * Math.Cos(Circleangle)));

                            Raylib.DrawLine(x,y,(int)(screenWidth / 2 + (Radius * Math.Sin(angle))), (int)(screenHeight / 2 + (Radius * Math.Cos(angle))), Color.PINK);

                        }
                    }
                }

                for (int i = 0; i < numberOfLED; i++)
                {

                    float angle = (float)(((float)(i + 1) / (numberOfLED))* 2 * Math.PI);

//                    Raylib.DrawCircle((int)(screenWidth/2 +(Radius * Math.Sin(angle))),(int)(screenHeight/2 + (Radius * Math.Cos(angle))),5, Color.BLACK);

                    angle += offset * (float)(Math.PI / 180);
                    
//                  if(drawRays)Radiate.Radiate.drawthis((int)(screenWidth/2 +(Radius * Math.Sin(angle))),(int)(screenHeight/2 + (Radius * Math.Cos(angle))), Color.RED);

                    Raylib.DrawCircle((int)(screenWidth/2 +(Radius * Math.Sin(angle))),(int)(screenHeight/2 + (Radius * Math.Cos(angle))),10, Color.RED);
                }




                   //controller update

                controller.Update(dt);

                ImGui.Begin("Simulation Settings");

                if( ImGui.Checkbox("Circle", ref circleSelect))
                {
                    squareSelect = !circleSelect;
                }
                if( ImGui.Checkbox("Square", ref squareSelect))
                {
                    circleSelect = !squareSelect;
                }

                ImGui.Checkbox("draw rays", ref drawRays);
               
                

                ImGui.Text("Set number of LEDS");
                ImGui.InputInt("i", ref numberOfLED);


                ImGui.Text("Set number of Sensors");
                ImGui.InputInt("b", ref numberOfSensors);


                ImGui.Text("Set Circle Radius");
                ImGui.SliderInt("a", ref Radius, 0, 1000);

                ImGui.Text("Set angle offset");
                ImGui.SliderFloat("k", ref offset, 1, 360/numberOfLED);

                if( ImGui.Button("Stagger alignment"))
                {
                    offset = 180 / numberOfLED;
                }

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

