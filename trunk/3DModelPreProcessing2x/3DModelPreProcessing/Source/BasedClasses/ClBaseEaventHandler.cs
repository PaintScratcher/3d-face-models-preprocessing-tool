using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using System.Diagnostics;
/**************************************************************************
*
*                          ModelPreProcessing
*
* Copyright (C)         Przemyslaw Szeptycki 2007     All Rights reserved
*
***************************************************************************/

/**
*   @file       ClBaseEaventHandler.cs
*   @brief      Base class for all objects which would like to get eavents
*   @author     Przemyslaw Szeptycki <pszeptycki@gmail.com>
*   @date       26-10-2007
*
*   @history
*   @item		26-10-2007 Przemyslaw Szeptycki     created at ECL (普查迈克) (بشاماك)
*/
namespace ModelPreProcessing
{
    public class ClBaseEaventHandler: IEventHandler
    {
        
        protected bool m_bLeftMouseButtonDown = false;
        protected bool m_bRightMouseButtonDown = false;
        protected int m_iMouseButtonDownXpos = 0;
        protected int m_iMouseButtonDownYpos = 0;
        //------------------------------------------------------

        public virtual void MouseButtonDown(object sender, MouseEventArgs e)
        {
            /* You cand override this method to get describing event*/
            if (e.Button == MouseButtons.Left)
                m_bLeftMouseButtonDown = true;

            if (e.Button == MouseButtons.Right)
                m_bRightMouseButtonDown = true;

            m_iMouseButtonDownXpos = e.X;
            m_iMouseButtonDownYpos = e.Y;
        }

        public virtual void MouseButtonUp(object sender, MouseEventArgs e)
        {
            /* You cand override this method to get describing event*/
            if (e.Button == MouseButtons.Left)
                m_bLeftMouseButtonDown = false;

            if (e.Button == MouseButtons.Right)
                m_bRightMouseButtonDown = false;
        }

        public virtual void MouseMove(object sender, MouseEventArgs e)
        {
            /* You cand override this method to get describing event*/
            /* DO NOTHING */
        }

        public virtual void MouseWheel(object sender, MouseEventArgs e)
        {
            /* You cand override this method to get describing event*/
            /* DO NOTHING */
        }

        public virtual void KeyDown(object sender, KeyEventArgs e)
        {
            /* You cand override this method to get describing event*/
            /* DO NOTHING */
        }

        public virtual void KeyUp(object sender, KeyEventArgs e)
        {
            /* You cand override this method to get describing event*/
            /* DO NOTHING */
        }

        public void RegisterForEvent(ClEventSender.eEvents p_eEvent)
        {
            ClEventSender.getInstance().RegisterForEvent(p_eEvent, this);
        }

        public void DeRegisterForAllEvent()
        {
            ClEventSender.getInstance().DeRegisterForAllEvents(this);
        }

        public void DeRegisterForEvent(ClEventSender.eEvents p_eEvent)
        {
            throw new Exception("Method DeregisterForEavent() is not implemented");
        }
    }
}
