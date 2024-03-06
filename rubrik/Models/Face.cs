using System;
using System.Collections.Generic;
using System.Text;

namespace rubrik.Models
{
    public class Face
    {
        public string Position; // So the face knows which side it is, for rotation calculation
        public string TLFace; public string TMFace; public string TRFace;           //arranged in a 3x3 grid, for visual simplicty 
        public string MLFace; public string MMFace; public string MRFace;
        public string BLFace; public string BMFace; public string BRFace;

        public void setAll(string colour, string position)
        {
            Position = position;
            TLFace = colour; TMFace = colour; TRFace = colour;
            MLFace = colour; MMFace = colour; MRFace = colour;
            BLFace = colour; BMFace = colour; BRFace = colour;
        }
    }

}
