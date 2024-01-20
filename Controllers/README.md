### DEPENDENCY INJECTION AND DEPENDENCY INVERSION (Implemented in ItemsController.cs):

```
    A normal scenario is that class A depends on class B. This means that class A is
    somehow constrained or restricted to the capabilities or B.

    Dependency injection is simply when instead of creating and object of B in the
    constructor of A, we instead pass/inject an instance of B as part of the constructor
    of A.

    Now, we could actually invert the dependency so that class B depends on class A. To
    achieve this we need to bring a Contract/Interface that sits in between of A and B.
    This is known as dependency inversion.

    This way class A depends on the Interface and class B also depends on this Interface.
    Having this Interface means that class B has to align with the interface and implement
    it.

    Moreover, if our class A depends not only on B but C, D, E, etc. We can have ServiceContainer,
    which will resolve, contruct, and inject these dependencies to our class A, so that these
    dependency objects (B, C, D, etc) get creted only once within the Service Container and are
    reused by many instances of class A.
