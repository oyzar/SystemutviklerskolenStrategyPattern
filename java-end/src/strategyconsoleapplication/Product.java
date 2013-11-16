package strategyconsoleapplication;

public class Product {
    private String name;
    private String recommendedBy;

    public Product(String name, String recommendedBy) {
        this.name = name;
        this.recommendedBy = recommendedBy;
    }

    public String getName() {
        return name;
    }

    public String getRecommendedBy() {
        return recommendedBy;
    }

    @Override
    public String toString() {
        return name + ", " + recommendedBy;
    }
}
