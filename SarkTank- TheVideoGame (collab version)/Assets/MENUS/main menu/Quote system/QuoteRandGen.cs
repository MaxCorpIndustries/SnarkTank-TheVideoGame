using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuoteRandGen : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    string[] quotes = new string[] { "'I hope everyone in the big bang theory gets into a big bang in Iraq.' \n\n\nTom Sweeny\n(2020)", "'I'll fuck her till her knees break.' \n\n\nTom Sweeny\n(2020)", "'Oh yeah Kobe exploded!' \n\n\nChirsRayGun\n(2020)", "'If there was a clown culling, I'm not saying I'd participate, but I'd get involved somewhere...' \n\n\nTom Sweeny\n(2020)", "'I'd love to just gun down progerians from a black unmarked helicopter' \n\n\nChirsRayGun\n(2020)", "'How about “what do you mean? The infinity stones make more sense then heaven”' \n\n\nTom Sweeny\n(2020)", "'Deith Kavid Keith David Keith David Keith David Keith David Keith David Keith David Keith David Keith David Keith David \nKeith David Keith David Keith David Keith David Keith David Keith David Keith David Keith David Keith David Keith David Keith David Keith David Keith David Keith David Keith David Keith David Keith David' \n\nChrisRayGun\n(2020)", "'I'd love to just gun down progerians from a black unmarked helicopter' \n\n\nChirsRayGun\n(2020)", "'I don't dream anymore, I just scream HATE until I pass out.' \n\n\nTom Sweeny\n(2020)", "'Oh man, why’d you get all your baby batter in my bum bum.' \n\n\nTom Sweeny\n(2020)", "'Ok so what I'm going to do is take your coffee, stir it with my penis (not even erect, a FLACID penis), then pee and spit in it. You are not going to get a non dick touched drink.' \n\n\nTom Sweeny\n(2020)", "'If I found you unconscious on the ground, I’d pogo stick your knees until they were just dust' \n\n\nTom Sweeny\n(2020)" , "'CUM TWINKIE' \n\nSomeBlackMailMan\n(2020)", "'You’re being a celestial simp right now' \n\nTom Sweeny\n(2020)", "'There is no point in time where seamen will not come out of my mouth' \n\nChrisRayGun\n(2020)", "'If it looks different I'm killing it' \n\nTom Sweeny\n(2020)", "'My favorite sound is the sound of a baseball bat breaking over a clowns head' \n\nTom Sweeny\n(2020)" };
    private int quote_max = 0;
    private int random_gen;


    // Start is called before the first frame update
    void Start()
    {
        quote_max = quotes.Length + 1;

        textMesh = GetComponent<TextMeshProUGUI>();
        random_gen = Random.Range(0, quote_max);
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = quotes[random_gen];
    }
}
