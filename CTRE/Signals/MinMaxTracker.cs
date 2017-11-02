﻿/*********************************************************************
 * Software License Agreement
 *
 * Copyright (C) 2016 Cross The Road Electronics.  All rights
 * reserved.
 *
 * Cross The Road Electronics (CTRE) licenses to you the right to 
 * compile and modify the following source for the sole purpose of  
 * expanding the feature set of the Hydro-Gear Etesia demo platform.
 * This is considered a derivative work that cannot be published,
 * distributed, sublicensed, or sold.
 *
 * CTRE does not license to you the right to use or modify in any 
 * other circumstance.
 * CTRE does not license to you the right to publish, 
 * distribute, sublicense, or sell copies in any circumstance.
 *
 * The above copyright notice and this permission notice shall be included 
 * in all copies or substantial portions of the Software.
 *
 * THE SOFTWARE AND DOCUMENTATION ARE PROVIDED "AS IS" WITHOUT
 * WARRANTY OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT
 * LIMITATION, ANY WARRANTY OF MERCHANTABILITY, FITNESS FOR A
 * PARTICULAR PURPOSE, TITLE AND NON-INFRINGEMENT. IN NO EVENT SHALL
 * CROSS THE ROAD ELECTRONICS BE LIABLE FOR ANY INCIDENTAL, SPECIAL, 
 * INDIRECT OR CONSEQUENTIAL DAMAGES, LOST PROFITS OR LOST DATA, COST OF
 * PROCUREMENT OF SUBSTITUTE GOODS, TECHNOLOGY OR SERVICES, ANY CLAIMS
 * BY THIRD PARTIES (INCLUDING BUT NOT LIMITED TO ANY DEFENSE
 * THEREOF), ANY CLAIMS FOR INDEMNITY OR CONTRIBUTION, OR OTHER
 * SIMILAR COSTS, WHETHER ASSERTED ON THE BASIS OF CONTRACT, TORT
 * (INCLUDING NEGLIGENCE), BREACH OF WARRANTY, OR OTHERWISE.
 *
********************************************************************/
namespace CTRE.Phoenix.Signals
{
    public class MinMaxTracker
    {
        public float Minimum { get; private set; }
        public float Maximum { get; private set; }
        public float Total { get; private set; }
        public uint Count { get; private set; }

        public float Range
        {
            get
            {
                if (Maximum < Minimum)
                    return float.MaxValue;
                return Maximum - Minimum;
            }
        }
        public void Clear()
        {
            Minimum = float.MaxValue / 10; /* give up some range so max - min is a safe operation */
            Maximum = float.MinValue / 10;
            Count = 0;
            Total = 0;
        }
        public void Process(float value)
        {
            if (Minimum > value) { Minimum = value; }
            if (Maximum < value) { Maximum = value; }

            Total += value;
            Count = Count + 1;
        }
    }
}