using Raylib_cs;
using ImGuiNET;
using System;

namespace ML
{

       
    class Program
    {
        const int screenWidth = 1200;
        const int screenHeight = 800;
        static IDictionary<int, float> ditheringOffsets = new Dictionary<int, float>();

        static void setDitherRandom(int NumberOfLeds, float spacing)
        {
            Random random = new Random();
            for (int i = 0; i < NumberOfLeds; i++)
            {
                ditheringOffsets[i] = spacing * (float)random.NextDouble();
                Console.WriteLine(ditheringOffsets[i]);
            }
        }

        

        public static void Main()
        {

            int numberOfLED = 1;

            int numberOfSensors = 1;

            int Radius = 100;

            float iterationSpeed = 1;
            float canIterate = 0;

            bool circleSelect = true;
            bool squareSelect = false;

            bool bottleCapDraw = false;

            bool drawRays = false;

            bool isDithering = false;

            bool iterateLEDs = false;

               
            float offset = 0;

            int iterationNumber = 0;

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
                        if (iterateLEDs)
                        {
                                if (!isDithering)
                                {
                                        float Circleangle = (float)((((float)(iterationNumber + 1) / (numberOfLED))) * 2 * Math.PI);

                                        Circleangle += offset * (float)(Math.PI / 180);

                                        int x = (int)(screenWidth / 2 + (Radius * Math.Sin(Circleangle)));
                                        int y = (int)(screenHeight / 2 + (Radius * Math.Cos(Circleangle)));

                                        Raylib.DrawLine(x,y,(int)(screenWidth / 2 + (Radius * Math.Sin(angle))), (int)(screenHeight / 2 + (Radius * Math.Cos(angle))), Color.PINK);

                                }
                                else
                                {
                                        float Circleangle = (float)((((float)(iterationNumber + 1) / (numberOfLED))) * 2 * Math.PI);

                                        Circleangle += offset * (float)(Math.PI / 180);
                                        Circleangle += ditheringOffsets[iterationNumber];

                                        int x = (int)(screenWidth / 2 + (Radius * Math.Sin(Circleangle)));
                                        int y = (int)(screenHeight / 2 + (Radius * Math.Cos(Circleangle)));

                                        Raylib.DrawLine(x,y,(int)(screenWidth / 2 + (Radius * Math.Sin(angle))), (int)(screenHeight / 2 + (Radius * Math.Cos(angle))), Color.PINK);

                                }

                            if(Raylib.GetTime() > canIterate)
                            {
                                canIterate = (float)Raylib.GetTime() + iterationSpeed;
                                iterationNumber++;
                                if (iterationNumber > numberOfLED)
                                {
                                    iterationNumber = 0;
                                }
                                
                            }
                        }
                        else
                        {
                            if (!isDithering)
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
                            else
                            {
                                for (int j = 0; j < numberOfLED; j++)
                                {
                                    float Circleangle = (float)((((float)(j + 1) / (numberOfLED))) * 2 * Math.PI);

                                    Circleangle += offset * (float)(Math.PI / 180);
                                    Circleangle += ditheringOffsets[j];

                                    int x = (int)(screenWidth / 2 + (Radius * Math.Sin(Circleangle)));
                                    int y = (int)(screenHeight / 2 + (Radius * Math.Cos(Circleangle)));

                                    Raylib.DrawLine(x,y,(int)(screenWidth / 2 + (Radius * Math.Sin(angle))), (int)(screenHeight / 2 + (Radius * Math.Cos(angle))), Color.PINK);

                                }

                            }

                        }
                    }
                }

                if (!isDithering)
                {
                    for (int i = 0; i < numberOfLED; i++)
                    {

                        float angle = (float)(((float)(i + 1) / (numberOfLED))* 2 * Math.PI);

    //                    Raylib.DrawCircle((int)(screenWidth/2 +(Radius * Math.Sin(angle))),(int)(screenHeight/2 + (Radius * Math.Cos(angle))),5, Color.BLACK);

                        angle += offset * (float)(Math.PI / 180);
                        
    //                  if(drawRays)Radiate.Radiate.drawthis((int)(screenWidth/2 +(Radius * Math.Sin(angle))),(int)(screenHeight/2 + (Radius * Math.Cos(angle))), Color.RED);

                        Raylib.DrawCircle((int)(screenWidth/2 +(Radius * Math.Sin(angle))),(int)(screenHeight/2 + (Radius * Math.Cos(angle))),10, Color.RED);
                    }
                }
                else
                {
                    for (int i = 0; i < numberOfLED; i++)
                    {

                        float angle = (float)(((float)(i + 1) / (numberOfLED))* 2 * Math.PI);

    //                    Raylib.DrawCircle((int)(screenWidth/2 +(Radius * Math.Sin(angle))),(int)(screenHeight/2 + (Radius * Math.Cos(angle))),5, Color.BLACK);

                        angle += offset * (float)(Math.PI / 180);
                        angle += ditheringOffsets[i];
                        
    //                  if(drawRays)Radiate.Radiate.drawthis((int)(screenWidth/2 +(Radius * Math.Sin(angle))),(int)(screenHeight/2 + (Radius * Math.Cos(angle))), Color.RED);

                        Raylib.DrawCircle((int)(screenWidth/2 +(Radius * Math.Sin(angle))),(int)(screenHeight/2 + (Radius * Math.Cos(angle))),10, Color.RED);
                    }
                }


                
                if (bottleCapDraw)
                {
                        Raylib.DrawCircle((int)Raylib.GetMousePosition().X,(int)Raylib.GetMousePosition().Y,(float)25, Color.RED);
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
                if( ImGui.Checkbox("Mouse = BottleCap (25mmRadius)", ref bottleCapDraw))
                {

                }

                ImGui.Checkbox("draw rays", ref drawRays);
               
                

                ImGui.Text("Set number of LEDS");
                ImGui.InputInt("i", ref numberOfLED);


                ImGui.Text("Set number of Sensors");
                ImGui.InputInt("b", ref numberOfSensors);


                ImGui.Text("Set Circle Radius");
                ImGui.SliderInt("mm Equivalent", ref Radius, 0, 1000);

                ImGui.Text("Set angle offset");
                ImGui.SliderFloat("k", ref offset, 1, 360/numberOfLED);

                if( ImGui.Button("Stagger alignment"))
                {
                    offset = 180 / numberOfLED;
                }

                if( ImGui.Button("Random Dither spacing"))
                {
                    isDithering = true;
                    float angle = (float)(((float)(1) / (numberOfLED))* 2 * Math.PI);
                    setDitherRandom(numberOfLED, angle);
                }

                if( ImGui.Button("Equal Spacing"))
                {
                    isDithering = false;
                }

                ImGui.Checkbox("Iterate Through LEDS", ref iterateLEDs);
                if (iterateLEDs)
                {
                    ImGui.Text("iteration Speed");
                    ImGui.SliderFloat("cycle/s", ref iterationSpeed, 0.1f, 2);
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

