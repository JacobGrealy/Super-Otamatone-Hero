using UnityEngine;
using System.Collections;

public static class OtamatoneColors{
    private static Color zone1 = new Color(4/250f,249/250f,00/250f);
    public static Color getZone1() { return zone1; }
    private static Color zone2 = Color.red;
    public static Color getZone2() { return zone2; }
    private static Color zone3 = Color.yellow;
    public static Color getZone3() { return zone3; }
    private static Color zone4 = new Color(0/250f, 238/250f, 249/250f);
    public static Color getZone4() { return zone4; }

    public static Color getZoneColor(int zone) {
        Color nextColor;
        switch (zone) {
            case 1:
                nextColor = OtamatoneColors.getZone1();
                break;
            case 2:
                nextColor = OtamatoneColors.getZone2();
                break;
            case 3:
                nextColor = OtamatoneColors.getZone3();
                break;
            case 4:
                nextColor = OtamatoneColors.getZone4();
                break;
            default:
                Debug.Log("Oh God, we have no Zone, what shall we do with the lazer????");
                nextColor = Color.black;
                break;
        }
        return nextColor;
    }
}
