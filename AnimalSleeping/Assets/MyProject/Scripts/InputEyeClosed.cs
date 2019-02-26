using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputEyeClosed
{
    /*
    static InputEyeClosed()
    {
        GameObject.Instantiate(Resources.Load(m_InputUpdateSupport));

        m_closeState = Fove.Managed.EFVR_Eye.Neither;

        m_closedNeither = new EyeClosedData(Fove.Managed.EFVR_Eye.Neither, false, false, false);
        m_closedLeft = new EyeClosedData(Fove.Managed.EFVR_Eye.Neither, false, false, false);
        m_closedRight = new EyeClosedData(Fove.Managed.EFVR_Eye.Neither, false, false, false);
        m_closedBoth = new EyeClosedData(Fove.Managed.EFVR_Eye.Neither, false, false, false);
    }

    static readonly string m_InputUpdateSupport = "InputEyeClosedUpdater";

    static private Fove.Managed.EFVR_Eye m_closeState;

    static private EyeClosedData m_closedNeither;
    static private EyeClosedData m_closedLeft;
    static private EyeClosedData m_closedRight;
    static private EyeClosedData m_closedBoth;

    static public void ClosedStateUpdate(Fove.Managed.EFVR_Eye state)
    {
        m_closeState = state;
    }

    static public void ClosedDataUpdate(Fove.Managed.EFVR_Eye state)
    {
        EyeClosedData closed;
        switch (state)
        {
            case Fove.Managed.EFVR_Eye.Neither:
                closed = m_closedNeither;
                break;
            case Fove.Managed.EFVR_Eye.Left:
                closed = m_closedLeft;
                break;
            case Fove.Managed.EFVR_Eye.Right:
                closed = m_closedRight;
                break;
            case Fove.Managed.EFVR_Eye.Both:
                closed = m_closedBoth;
                break;
            default:
                closed = m_closedNeither;
                break;
        }

        if (m_closeState == state)
        {
            if (m_closeState == closed.m_cashState)
            {
                // Key True
                ClosedKeyUpdate(closed, false, true, false);
            }
            else
            {
                // Down True
                ClosedKeyUpdate(closed, true, false, false);
            }
        }
        else
        {
            if (closed.m_isDown || closed.m_isKey)
            {
                // Up True
                ClosedKeyUpdate(closed, false, false, true);
            }
            else
            {
                // All False
                ClosedKeyUpdate(closed, false, false, false);
            }
        }
        closed.m_cashState = m_closeState;
    }

    static private void ClosedKeyUpdate(EyeClosedData closed, bool isDown, bool isKey, bool isUp)
    {
        closed.m_isDown = isDown;
        closed.m_isKey = isKey;
        closed.m_isUp = isUp;
    }

    static public bool GetCloseNeitherDown() { return m_closedNeither.m_isDown; }
    static public bool GetCloseNeither() { return m_closedNeither.m_isKey; }
    static public bool GetCloseNeitherUp() { return m_closedNeither.m_isUp; }

    static public bool GetCloseLeftDown() { return m_closedLeft.m_isDown; }
    static public bool GetCloseLeft() { return m_closedLeft.m_isKey; }
    static public bool GetCloseLeftUp() { return m_closedLeft.m_isUp; }

    static public bool GetCloseRightDown() { return m_closedRight.m_isDown; }
    static public bool GetCloseRight() { return m_closedRight.m_isKey; }
    static public bool GetCloseRightUp() { return m_closedRight.m_isUp; }

    static public bool GetCloseBothDown() { return m_closedBoth.m_isDown; }
    static public bool GetCloseBoth() { return m_closedBoth.m_isKey; }
    static public bool GetCloseBothUp() { return m_closedBoth.m_isUp; }
    */
}

public class EyeClosedData
{
    public Fove.Managed.EFVR_Eye m_cashState;
    public bool m_isDown;
    public bool m_isKey;
    public bool m_isUp;

    public EyeClosedData(Fove.Managed.EFVR_Eye state, bool isDown, bool isKey, bool isUp)
    {
        m_cashState = state;
        m_isDown = isDown;
        m_isKey = isKey;
        m_isUp = isUp;
    }
}