using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Math
{
	// Thanks to Dennis Ritchie for making the C programming language
	// Thanks Arduino Docs for publicising (https://cdn.arduino.cc/reference/en/language/functions/math/map/)
	// Thanks to Liav for creating the original titanUtil
	// Thanks to Usaid and David for making critical contributions to titanUtil
	// Thanks Ryan for adding it into titanUtil
	// Thanks Colin for refactoring titanUtil
	// Thanks to Tauseef for emotional support
	// Thanks to king john for managing governmental spending and thermonuclear war bunkers
	// Thanks to ?? for creating the universe
	// at this point very apologetically stolen from titanUtil
	// Citing your sources is important children...
	// anyone else?????????
	public static float map(float val, float in_min, float in_max, float out_min, float out_max)
	{
		return (val - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
	}
}
