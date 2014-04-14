Design patterns workshop - Strategy pattern assignments 
=======================================================

## Overview

* Background
* Business requirements
* Technical requirements
* Patterns & Anti-patterns
* Assignments
* Summary

## Background

You have been hired as a consultant for the online retailing company Contoso Ltd. which run an e-commerce website with a in-house developed sales system as the back-end. The sales system suffers from quality issues: the code lacks a clear structure, good readability and have a high maintenence cost. They want you to come in and create a new system and apply best-practice design and SOLID coding principles.

## Business requirements

The component which you have been assigned to is a recommendation component for products. Users who visit their website should see suggested products based on given properties, e.g. user properties, seasonal properties, product properties. This way they can target spesific products to spesific users and this will lead to a higher conversion rate for visitors that see a product and end up creating new sales orders with this product.

The recommendation system must be extendible becasue there are new properties being suggested and being created all of the time from senior sales management.

At the moment, these are the properties that are approved and should be implemented (also called "SalesMode" internally in the system): ***Gender***, ***Low-cost*** and ***Season***

* **Gender**: If the user is a male, then present him with products marked as appropriate for males (razor blades, men-magazines etc)
* **Low-cost**: If the product is marked as a low-cost product, use this to show the products to cost-aware users (99-cents items etc)
* **Season**: If it's mid-winter then the system should recommend skiis, ice-skates, winter clothing etc.

## Technical requirements

The customer wants you to build the system as a proof-of-concept console application.

### Patterns & Anti-patterns

Refactor in: *Strategy, Inversion of Control*

Refactor out anti-patterns: *Arrow, Blob*

## Assignment tasks

### Java-version of the assignments

Java version av oppgaver er beskrivet på Design Patterns workshopoppgaver i Java.

### Assignment task #1

In the method `static void Main(string[] args)` in `Program.cs` you see there are instances of hard-coded `SalesMode` being used in a nested if-block (Arrow Anti-pattern) that selects recommender classes. Replace this with an implementation of the **Strategy pattern** for selecting the appropriate product recommender in runtime, based on a `SalesMode` as input value from the console. As an additional option, read customer's gender from the console also and use this value to get even more precise product recommendations.

Input parameters:

* **SalesMode** as a number from the console (0=Gender, 1=Low-cost, 2=Season)
* **Gender** as a number from the console (0=Male, 1=Female)

Output to console:

	Format: [Product name] - Recommender: [the type of the IProductRecommender]
	Example: Niva hand cream, Recommender: GenderProductRecommender
 

a) Read `SalesMode` as input from console into a local variable called `salesMode`

b) Read `Gender` as input from console into a property called `Gender` on a `Customer`-class.

c) Implement the Strategy-classes `GenderProductRecommender`, `LowCostProductRecommender` and `SeasonProductRecommender`.


> Hint: Use an arbitrary product name. Implementing or connecting to a product database is outside the scope of these assignments.

d) Implement the method `public Product Recommend(SalesMode salesMode, Customer customer)` in the `SalesEngine`-class

e) Create a new local variable called `salesEngine` and instantiate an object of type `SalesEngine`. Provide it with instantiated recommender-instances in its constructor.

f) Supply `salesMode` and `customer` to the `Recommend`-method of `salesEngine` and retrieve a product.
 

You have now a working product-recommender that selects an `IProductRecommender`-implementation at runtime! It selects a recommender based on a `SalesMode` and a customer with a `Gender`-property.

This can be improved upon further by using *IoC* and *Dependency Injection* to retrieve `SalesEngine` and provide it with the product-recommenders rather than instantiating them directly. See assignment task #2.

### Assignment task #2

You have now implemented all of the classes needed to meet the requirements, so now you can bind it all together with *IoC* ([Autofac](http://autofac.org/)) to retrieve an instantiated `SalesEngine`-object and find a recommended product based on given `SalesMode` at runtime.
 

a) Install the NuGet-package "Autofac".

b) Initialize Autofac after you have read the `SalesMode` into `salesMode` from the console in `static void Main(string[] args)` in `Program.cs` by adding the following code:

	var containerBuilder = new ContainerBuilder();
	
	containerBuilder.RegisterModule<AutofacBuilder>();
	
	using (var container = containerBuilder.Build())	
	{	
		// TODO: Assigment 2 c) & d)	
	}

Create a new class called `AutofacBuilder`: `internal class AutofacBuilder : Autofac.Module`.

c) Change the method `public Product Recommend(SalesMode salesMode, Customer customer)` in the `SalesEngine`-class to match on `Metadata`

> Hint: Create a new constructor for `SalesEngine` that takes in a list of all the recommenders:
> 
	public SalesEngine(IEnumerable<Lazy<IProductRecommender, ProductRecommenderMetadata>> recommenders)
    {
        _recommenders = recommenders;
    } 
> 
> In the list `_recommenders` you will find a match on a recommender that has the property `Metadata` equaling the method parameter `salesMode`. Run its `Recommend()`-method to find a product:

> _recommenders.FirstOrDefault(e => e.Metadata.SalesMode == salesMode).Value.Recommend(customer);

d) Implement the method `protected override void Load(ContainerBuilder builder)` in the `AutofacBuilder`-class

* Register the type `SalesEngine` with `AsImplementedInterfaces`
* Register the type `GenderProductRecommender` with `AsImplementedInterfaces` and with metadata class `ProductRecommenderMetadata` for property `SalesMode` which should be set to `SalesMode.Gender`.
* Do the equivalent to `LowPriceProductRecommender` and `SeasonalProductRecommender` with `SalesMode.LowCost` and `SalesMode.Seasonal`

e) Modify your local variable `salesEngine` to use Autofac to resolve `ISalesEngine` to the type `SalesEngine`.


## Summary

After you have completed all of the assignment tasks you should be able to get a recommended product returned the system based on a given `SalesMode`.

You have now created a reusable and isolated product recommendation component that can be imported into and used in the e-commerce system by providing a `SalesMode` and a `Customer`-object, and getting products back via a `IProductRecommender` at runtime.

You have implemented the Strategy-pattern by using the `SalesEngine` as the Context and different implementations of `IProductRecommender` as concrete Strategies. `IProductRecommender` is adhering to the Open/Closed-principle by being open for extensions (more recommenders, more customer-properties) but closed for modification. The team can therefore now concentrate on creating Strategy-implementations and testing these without touching the `IProductRecommender`-interface or the `SalesEngine`.

You have also seen that IoC and Dependency Inversion lets you code against interfaces/abstractions and not concrete implementations, allowing a better abstraction level in the code, higher testability and reduces coupling between classes (low coupling / high cohesion)

If you have achieved all of this then one can say that you have done a SOLID piece of work :)