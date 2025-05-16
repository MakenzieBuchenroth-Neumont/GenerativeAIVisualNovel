public class Manager {
    private static Manager singleton; //holds the one instance of the class

    private Manager(){} //private contructor to prevent outside instantiation

    public static Manager getSingleton() {
        if (singleton == null) {
            singleton = new Manager();
        }
        return singleton;
    }
}