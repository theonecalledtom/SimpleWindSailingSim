using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWindSailingSim
{
    public partial class SimpleWindSailingSim : Form
    {
        class PolarData
        {
            public double GetBoatSpeed(double windSpeed, double twa)
            {
                return 5.0;
            }
        }

        class Vector2
        {
            public double m_X;
            public double m_Y;
            public Vector2() { }
            public Vector2(double x, double y)
            {
                m_X = x;
                m_Y = y;
            }
        }

        class WindField
        {
            Vector2 m_WindVector_TopLeft;
            Vector2 m_WindVector_TopRight;
            Vector2 m_WindVector_BottomLeft;
            Vector2 m_WindVector_BottomRight;

            public void SetField(Vector2 topLeft, Vector2 topRight, Vector2 bottomLeft, Vector2 bottomRight)
            {
                m_WindVector_TopLeft = topLeft;
                m_WindVector_TopRight = topRight;
                m_WindVector_BottomLeft = bottomLeft;
                m_WindVector_BottomRight = bottomRight;
            }

            public Vector2 GetField(double x, double y)
            {
                Vector2 blendTop = new Vector2(   
                                    m_WindVector_TopLeft.m_X + (m_WindVector_TopRight.m_X - m_WindVector_TopLeft.m_X) * x,
                                    m_WindVector_TopLeft.m_Y + (m_WindVector_TopRight.m_Y - m_WindVector_TopLeft.m_Y) * x
                                );
                Vector2 blendBottom = new Vector2(   
                                    m_WindVector_BottomLeft.m_X + (m_WindVector_BottomRight.m_X - m_WindVector_BottomLeft.m_X) * x,
                                    m_WindVector_BottomLeft.m_Y + (m_WindVector_BottomRight.m_Y - m_WindVector_BottomLeft.m_Y) * x
                                );
                Vector2 blendY = new Vector2(
                                    blendTop.m_X + (blendBottom.m_X - blendTop.m_X) * y,
                                    blendTop.m_Y + (blendBottom.m_Y - blendTop.m_Y) * y
                                );
                return blendY;
            }
        }

        class RecordedBoatData
        {
            public Vector2 m_Position;
            public double m_Heading;
        }

        PolarData m_PolarData = new PolarData();
        WindField m_WindField = new WindField();
        List<List<RecordedBoatData>> m_ListOfRoutes = new List<List<RecordedBoatData>>();
        bool m_bRecording = false;
        bool m_bOnPort = false;

        void UpdateSim(double timeStep, bool bShouldTack)
        {
            if (!m_bRecording)
            {
                return;
            }
            if (bShouldTack)
            {
                m_bOnPort = !m_bOnPort;
            }
            Vector2 currentPos = m_ListOfRoutes.Last().Last().m_Position;
            Vector2 windAtPos = m_WindField.GetField(currentPos.m_X, currentPos.m_Y);

            //float 
        }

        public SimpleWindSailingSim()
        {
            InitializeComponent();
        }
    }
}
