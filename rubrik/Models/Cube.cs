using System;
using System.Collections.Generic;
using System.Text;

namespace rubrik.Models
{
    public class Cube
    {
        public Face UFace = new Face();
        public Face LFace = new Face(); public Face FFace = new Face(); public Face RFace = new Face(); public Face BFace = new Face();     //arranged in printout shape for visual simplicity
        public Face DFace = new Face();

        public void setDefaultCubeColours()
        {
            UFace.setAll("White", "Up");
            LFace.setAll("Orange", "Left"); FFace.setAll("Green", "Front"); RFace.setAll("Red", "Right"); BFace.setAll("Blue", "Back");
            DFace.setAll("Yellow", "Down");
        }



        public void RotateFace(Face selectedFace, bool clockwise)
        {
            //Do main face first start with get a copy of the colours
            string TLColour = selectedFace.TLFace; string TMColour = selectedFace.TMFace; string TRColour = selectedFace.TRFace;
            string MLColour = selectedFace.MLFace; /*dont change the middle face*/        string MRColour = selectedFace.MRFace;
            string BLColour = selectedFace.BLFace; string BMColour = selectedFace.BMFace; string BRColour = selectedFace.BRFace;

            if (clockwise)
            {
                // Assign the colours back the faces
                selectedFace.TLFace = BLColour; selectedFace.TMFace = MLColour; selectedFace.TRFace = TLColour;
                selectedFace.MLFace = BMColour; /*dont change the middle face*/ selectedFace.MRFace = TMColour;
                selectedFace.BLFace = BRColour; selectedFace.BMFace = MRColour; selectedFace.BRFace = TRColour;
            }
            else
            {
                // Assign the colours back the faces
                selectedFace.TLFace = TRColour; selectedFace.TMFace = MRColour; selectedFace.TRFace = BRColour;
                selectedFace.MLFace = TMColour; /*dont change the middle face*/ selectedFace.MRFace = BMColour;
                selectedFace.BLFace = TLColour; selectedFace.BMFace = MLColour; selectedFace.BRFace = BLColour;
            }

            //now to the surrounding faces.
            List<Face> surrounding = FindSurroundingFaces(selectedFace);
            List<string> BColourList;
            List<string> LColourList;
            List<string> TColourList;
            List<string> RColourList;


            switch (selectedFace.Position)
            {
                case "Up":
                    TColourList = GetSideColours(surrounding[0], "Top");
                    RColourList = GetSideColours(surrounding[1], "Top");
                    BColourList = GetSideColours(surrounding[2], "Top");
                    LColourList = GetSideColours(surrounding[3], "Top");

                    if (clockwise)
                    {
                        RecolourSide(LColourList, surrounding[0], "Top");
                        RecolourSide(TColourList, surrounding[1], "Top");
                        RecolourSide(RColourList, surrounding[2], "Top");
                        RecolourSide(BColourList, surrounding[3], "Top");
                    }
                    else
                    {
                        RecolourSide(RColourList, surrounding[0], "Top");
                        RecolourSide(BColourList, surrounding[1], "Top");
                        RecolourSide(LColourList, surrounding[2], "Top");
                        RecolourSide(TColourList, surrounding[3], "Top");
                    }
                    break;
                case "Left":
                    TColourList = GetSideColours(surrounding[0], "Left");
                    RColourList = GetSideColours(surrounding[1], "Left");
                    BColourList = GetSideColours(surrounding[2], "Left");
                    LColourList = GetSideColours(surrounding[3], "Right");

                    if (clockwise)
                    {
                        RecolourSide(LColourList, surrounding[0], "Left");
                        RecolourSide(TColourList, surrounding[1], "Left");
                        RecolourSide(RColourList, surrounding[2], "Left");
                        RecolourSide(BColourList, surrounding[3], "Right");
                    }
                    else
                    {
                        RecolourSide(RColourList, surrounding[0], "Left");
                        RecolourSide(BColourList, surrounding[1], "Left");
                        RecolourSide(LColourList, surrounding[2], "Left");
                        RecolourSide(TColourList, surrounding[3], "Right");
                    }
                    break;
                case "Front":
                    TColourList = GetSideColours(surrounding[0], "Bottom");
                    RColourList = GetSideColours(surrounding[1], "Left");
                    BColourList = GetSideColours(surrounding[2], "Top");
                    LColourList = GetSideColours(surrounding[3], "Right");

                    if (clockwise)
                    {
                        RecolourSide(LColourList, surrounding[0], "Bottom");
                        RecolourSide(TColourList, surrounding[1], "Left");
                        RecolourSide(RColourList, surrounding[2], "Top");
                        RecolourSide(BColourList, surrounding[3], "Right");
                    }
                    else
                    {
                        RecolourSide(RColourList, surrounding[0], "Bottom");
                        RecolourSide(BColourList, surrounding[1], "Left");
                        RecolourSide(LColourList, surrounding[2], "Top");
                        RecolourSide(TColourList, surrounding[3], "Right");
                    }
                    break;
                case "Right":
                    TColourList = GetSideColours(surrounding[0], "Right");
                    RColourList = GetSideColours(surrounding[1], "Left");
                    BColourList = GetSideColours(surrounding[2], "Right");
                    LColourList = GetSideColours(surrounding[3], "Right");

                    if (clockwise)
                    {
                        RecolourSide(LColourList, surrounding[0], "Right");
                        RecolourSide(TColourList, surrounding[1], "Left");
                        RecolourSide(RColourList, surrounding[2], "Right");
                        RecolourSide(BColourList, surrounding[3], "Right");
                    }
                    else
                    {
                        RecolourSide(RColourList, surrounding[0], "Right");
                        RecolourSide(BColourList, surrounding[1], "Left");
                        RecolourSide(LColourList, surrounding[2], "Right");
                        RecolourSide(TColourList, surrounding[3], "Right");
                    }
                    break;
                case "Back":
                    TColourList = GetSideColours(surrounding[0], "Top");
                    RColourList = GetSideColours(surrounding[1], "Left");
                    BColourList = GetSideColours(surrounding[2], "Bottom");
                    LColourList = GetSideColours(surrounding[3], "Right");

                    if (clockwise)
                    {
                        RecolourSide(LColourList, surrounding[0], "Top");
                        RecolourSide(TColourList, surrounding[1], "Left");
                        RecolourSide(RColourList, surrounding[2], "Bottom");
                        RecolourSide(BColourList, surrounding[3], "Right");
                    }
                    else
                    {
                        RecolourSide(RColourList, surrounding[0], "Top");
                        RecolourSide(BColourList, surrounding[1], "Left");
                        RecolourSide(LColourList, surrounding[2], "Bottom");
                        RecolourSide(TColourList, surrounding[3], "Right");
                    }
                    break;
                case "Down":
                    TColourList = GetSideColours(surrounding[0], "Bottom");
                    RColourList = GetSideColours(surrounding[1], "Bottom");
                    BColourList = GetSideColours(surrounding[2], "Bottom");
                    LColourList = GetSideColours(surrounding[3], "Bottom");

                    if (clockwise)
                    {
                        RecolourSide(LColourList, surrounding[0], "Bottom");
                        RecolourSide(TColourList, surrounding[1], "Bottom");
                        RecolourSide(RColourList, surrounding[2], "Bottom");
                        RecolourSide(BColourList, surrounding[3], "Bottom");
                    }
                    else
                    {
                        RecolourSide(RColourList, surrounding[0], "Bottom");
                        RecolourSide(BColourList, surrounding[1], "Bottom");
                        RecolourSide(LColourList, surrounding[2], "Bottom");
                        RecolourSide(TColourList, surrounding[3], "Bottom");
                    }
                    break;
                default:
                    throw new Exception("Found invalid face for : RotateFace");
            };
        }
        public List<Face> FindSurroundingFaces(Face selectedFace)
        {
            return selectedFace.Position switch
            {
                //always return in order of Face above, to the right, below, and to the left
                "Up" => (new List<Face> { BFace, RFace, FFace, LFace }),
                "Left" => (new List<Face> { UFace, FFace, DFace, BFace }),
                "Front" => (new List<Face> { UFace, RFace, DFace, LFace }),
                "Right" => (new List<Face> { UFace, BFace, DFace, FFace }),
                "Back" => (new List<Face> { UFace, LFace, DFace, RFace }),
                "Down" => (new List<Face> { FFace, RFace, BFace, LFace }),
                _ => throw new Exception("Found invalid face for : FindSurroundingFaces"),
            };
        }

        public List<string> GetSideColours(Face inputFace, string side)
        {
            switch (side)
            {
                case "Top":
                    return new List<string> { inputFace.TLFace, inputFace.TMFace, inputFace.TRFace };
                case "Right":
                    return new List<string> { inputFace.TRFace, inputFace.MRFace, inputFace.BRFace };
                case "Bottom":
                    return new List<string> { inputFace.BRFace, inputFace.BMFace, inputFace.BLFace };
                case "Left":
                    return new List<string> { inputFace.BLFace, inputFace.MLFace, inputFace.TLFace };
                default:
                    throw new Exception("Found invalid side for : GetSideColours");
            };
        }
        public void RecolourSide(List<String> replacementColours, Face affectedFace, string side)
        {
            switch (side)
            {
                case "Top":
                    affectedFace.TLFace = replacementColours[0];
                    affectedFace.TMFace = replacementColours[1];
                    affectedFace.TRFace = replacementColours[2];
                    break;
                case "Right":
                    affectedFace.TRFace = replacementColours[0];
                    affectedFace.MRFace = replacementColours[1];
                    affectedFace.BRFace = replacementColours[2];
                    break;
                case "Bottom":
                    affectedFace.BRFace = replacementColours[0];
                    affectedFace.BMFace = replacementColours[1];
                    affectedFace.BLFace = replacementColours[2];
                    break;
                case "Left":
                    affectedFace.BLFace = replacementColours[0];
                    affectedFace.MLFace = replacementColours[1];
                    affectedFace.TLFace = replacementColours[2];
                    break;
                default:
                    throw new Exception("Found invalid side for : GetSideColours");
            };
        }

        public void outputCube()
        {
            const int columnWidthL = 35;
            const int columnWidthR = 6;
            Console.WriteLine("{0} │ {1} │ {2}", UFace.TLFace.PadLeft(columnWidthL).PadRight(columnWidthR), UFace.TMFace.PadRight(columnWidthR), UFace.TRFace.PadRight(columnWidthR));
            Console.WriteLine("{0} │ {1} │ {2}", UFace.MLFace.PadLeft(columnWidthL).PadRight(columnWidthR), UFace.MMFace.PadRight(columnWidthR), UFace.MRFace.PadRight(columnWidthR));
            Console.WriteLine("{0} │ {1} │ {2}", UFace.BLFace.PadLeft(columnWidthL).PadRight(columnWidthR), UFace.BMFace.PadRight(columnWidthR), UFace.BRFace.PadRight(columnWidthR));
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0} │ {1} │ {2} │││ {3} │ {4} │ {5} │││ {6} │ {7} │ {8} │││ {9} │ {10} │ {11} ", LFace.TLFace.PadRight(columnWidthR), LFace.TMFace.PadRight(columnWidthR), LFace.TRFace.PadRight(columnWidthR).PadRight(columnWidthR), FFace.TLFace.PadRight(columnWidthR), FFace.TMFace.PadRight(columnWidthR), FFace.TRFace.PadRight(columnWidthR).PadRight(columnWidthR), RFace.TLFace.PadRight(columnWidthR), RFace.TMFace.PadRight(columnWidthR), RFace.TRFace.PadRight(columnWidthR).PadRight(columnWidthR), BFace.TLFace.PadRight(columnWidthR), BFace.TMFace.PadRight(columnWidthR), BFace.TRFace.PadRight(columnWidthR));
            Console.WriteLine("{0} │ {1} │ {2} │││ {3} │ {4} │ {5} │││ {6} │ {7} │ {8} │││ {9} │ {10} │ {11} ", LFace.MLFace.PadRight(columnWidthR), LFace.MMFace.PadRight(columnWidthR), LFace.MRFace.PadRight(columnWidthR).PadRight(columnWidthR), FFace.MLFace.PadRight(columnWidthR), FFace.MMFace.PadRight(columnWidthR), FFace.MRFace.PadRight(columnWidthR).PadRight(columnWidthR), RFace.MLFace.PadRight(columnWidthR), RFace.MMFace.PadRight(columnWidthR), RFace.MRFace.PadRight(columnWidthR).PadRight(columnWidthR), BFace.MLFace.PadRight(columnWidthR), BFace.MMFace.PadRight(columnWidthR), BFace.MRFace.PadRight(columnWidthR));
            Console.WriteLine("{0} │ {1} │ {2} │││ {3} │ {4} │ {5} │││ {6} │ {7} │ {8} │││ {9} │ {10} │ {11} ", LFace.BLFace.PadRight(columnWidthR), LFace.BMFace.PadRight(columnWidthR), LFace.BRFace.PadRight(columnWidthR).PadRight(columnWidthR), FFace.BLFace.PadRight(columnWidthR), FFace.BMFace.PadRight(columnWidthR), FFace.BRFace.PadRight(columnWidthR).PadRight(columnWidthR), RFace.BLFace.PadRight(columnWidthR), RFace.BMFace.PadRight(columnWidthR), RFace.BRFace.PadRight(columnWidthR).PadRight(columnWidthR), BFace.BLFace.PadRight(columnWidthR), BFace.BMFace.PadRight(columnWidthR), BFace.BRFace.PadRight(columnWidthR));
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0} │ {1} │ {2}", DFace.TLFace.PadLeft(columnWidthL).PadRight(columnWidthR), DFace.TMFace.PadRight(columnWidthR), DFace.TRFace.PadRight(columnWidthR));
            Console.WriteLine("{0} │ {1} │ {2}", DFace.MLFace.PadLeft(columnWidthL).PadRight(columnWidthR), DFace.MMFace.PadRight(columnWidthR), DFace.MRFace.PadRight(columnWidthR));
            Console.WriteLine("{0} │ {1} │ {2}", DFace.BLFace.PadLeft(columnWidthL).PadRight(columnWidthR), DFace.BMFace.PadRight(columnWidthR), DFace.BRFace.PadRight(columnWidthR));
        }
    }

}
