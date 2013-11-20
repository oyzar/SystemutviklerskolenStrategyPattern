package strategyconsoleapplication;

public class ProgramUsage {

    public static void checkUsage(String [] args) {
        if (args.length != 2) {
            System.out.println("usage: program gender sales-mode");
            System.out.printf("gender: { %s }\n", Gender.MALE.name().toLowerCase() + ", " + Gender.FEMALE.name().toLowerCase());
            System.out.printf("sales-mode: { %s }\n", getAvailableSalesModes());
            System.exit(- 1);
        }
    }

    private static String getAvailableSalesModes() {
        StringBuilder builder = new StringBuilder();
        SalesMode [] salesModes = SalesMode.values();
        for (int i = 0; i < salesModes.length; i++) {
            SalesMode mode =  salesModes[i];
            builder.append(mode.name().toLowerCase());
            if (i < salesModes.length - 1) {
                builder.append(", ");
            }
        }
        return builder.toString();
    }
}
