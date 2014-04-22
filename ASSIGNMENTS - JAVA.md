Assignment 1

The Main class for the Java program is Program.java. The method public static void main(String [] args) in Program.java reads in two parameters from the command line and parses this to a Gender and a SalesMode object. These objects are then used in a huge nested if bloc (Arrow Anti-Pattern) which selects the recommanded product. First part of the assignment consists of removing the huge nested 'if' bloc and selecting the right recommanded strategy in runtime.

Input:

    Read in Gender as text and resolve to an enum
    Read in SalesMode as text and resolve to an enum

Output

    Name of the product and selected type which implements the ProductRecommender out to the Console
        Example: "<product>, Recommender: <recommenders class name>"

a) Implement parsing av input text from konsoll to local variables "gender" (Gender) and "salesMode" (SalesMode)

b) Create a new interface interface ProductRecommender that has two methods: "Product recommend(Customer customer)" and "boolean supports(SalesMode salesMode)"

c) Implement Strategy-classes GenderProductRecommender, LowPriceProductRecommender and SeasonalProductRecommender.

    Use example product names as implementing the product database is outside of this assigments scope.

d) Instantiate SalesEngine implementation with available ProductRecommender class

e) Implement SalesEngine method Product recommend(SalesMode salesMode, Customer customer) so as to use the right  ProductRecommender to recommend a product

Assignment 2

Java developers may use PicoContainer as provided under the codebase directory. The PicoContainer framework is under 324 KB and lies under ${project.home}/java-lib/ directory.

a) Include ${project.home}/java-lib/ directory under the compile and run-time library path for your IDE

b) Add container startup code in Program.java (or any place you may find suitable):

MutablePicoContainer picoContainer = new PicoBuilder().build();

c) Create a new local variable "salesEngine" and use MutablePicoContainer to resolve SalesEngine to the type SalesEngineImpl.

d) Use SalesEngine's recommend() with SalesMode and Customer parameters
