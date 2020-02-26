using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyStrokesToString
{
    Dictionary<KeyCode, string> dictionary;
    public KeyStrokesToString()
    {
        dictionary = new Dictionary<KeyCode, string>();
        dictionary[KeyCode.Alpha1] = "1";
        dictionary[KeyCode.Alpha2] = "2";
        dictionary[KeyCode.Alpha3] = "3";
        dictionary[KeyCode.Alpha4] = "4";
        dictionary[KeyCode.Alpha5] = "5";
        dictionary[KeyCode.Alpha6] = "6";
        dictionary[KeyCode.Alpha7] = "7";
        dictionary[KeyCode.Alpha8] = "8";
        dictionary[KeyCode.Alpha9] = "9";
        dictionary[KeyCode.Alpha0] = "0";

        dictionary[KeyCode.A] = "a";
        dictionary[KeyCode.B] = "b";
        dictionary[KeyCode.C] = "c";
        dictionary[KeyCode.D] = "d";
        dictionary[KeyCode.E] = "e";
        dictionary[KeyCode.F] = "f";
        dictionary[KeyCode.G] = "g";
        dictionary[KeyCode.H] = "h";
        dictionary[KeyCode.I] = "i";
        dictionary[KeyCode.J] = "j";
        dictionary[KeyCode.K] = "k";
        dictionary[KeyCode.L] = "l";
        dictionary[KeyCode.M] = "m";
        dictionary[KeyCode.N] = "n";
        dictionary[KeyCode.O] = "o";
        dictionary[KeyCode.P] = "p";
        dictionary[KeyCode.R] = "r";
        dictionary[KeyCode.S] = "s";
        dictionary[KeyCode.T] = "t";
        dictionary[KeyCode.U] = "u";
        dictionary[KeyCode.V] = "v";
        dictionary[KeyCode.Z] = "z";

        dictionary[KeyCode.Q] = "q";
        dictionary[KeyCode.W] = "w";
        dictionary[KeyCode.Y] = "y";

        dictionary[KeyCode.Comma] = ",";
        dictionary[KeyCode.Ampersand] = "&";
        dictionary[KeyCode.Asterisk] = "*";
        dictionary[KeyCode.At] = "@";
        dictionary[KeyCode.Colon] = ":";
        dictionary[KeyCode.Equals] = "=";
        dictionary[KeyCode.Exclaim] = "!";
        dictionary[KeyCode.Greater] = ">";
        dictionary[KeyCode.Dollar] = "$";
        dictionary[KeyCode.Hash] = "#";
        dictionary[KeyCode.KeypadDivide] = "/";
        dictionary[KeyCode.Less] = "<";
        dictionary[KeyCode.KeypadPlus] = "+";
        dictionary[KeyCode.Period] = ".";
        dictionary[KeyCode.Percent] = "%";
        dictionary[KeyCode.Underscore] = "_";
        dictionary[KeyCode.Slash] = "/";
    }

    public string process(string state, System.Func<KeyCode, bool> f, bool upper)
    {

        if(f(KeyCode.Return))
        {
            return "";
        }
        
        if(f(KeyCode.Space))
        {
            return state + " ";
        }

        if (f(KeyCode.Backspace))
        {
            if (state.Length != 0)
            {

                return state.Remove(state.Length - 1);
            }
            else
            {
                return "";
            }
        }

        
        foreach (KeyValuePair<KeyCode, string> entry in dictionary)
        {

            if (f(entry.Key))
            {
                if (upper)
                {
                    return state + entry.Value.ToUpper();
                }
                else
                {
                    return state + entry.Value;
                }
            }
        }

        return state;
    }
}
