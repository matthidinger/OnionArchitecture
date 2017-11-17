## Onion Architecture with ASP.NET MVC

### This source code is used with a talk I give on Onion Architecture

*Note:* this repo was migrated from CodePlex and is from a 2012 talk.

Onion Architecture is a specific type of solution architecture that was first introduced to me by Jeffrey Palermo. Over the years nearly every project I’ve worked on used a traditional layered architecture under the guise of loose coupling. Yet in every case as the project progressed we realized more and more that our layer abstractions weren’t actually abstractions at all. We were still building our application on top of a specific technology, which is sure to change over time. Additionally, when we needed to add a new feature to the UI, the developer is completely free to put the code for his feature in any layer he chooses — from the presentation layer on down, or perhaps in the dreaded “Shared/common/utility” project.

Onion architecture helps us fight this by enforcing true loose coupling. As you will see throughout the talk, our UI layer has no reference to any infrastructure/DAL, just the Core business logic. Even the business logic (Core) has no access to any infrastructure concerns. Rather than build on top of the database, it externalizes it. It defines what it needs using its own interfaces, and they are implemented as far outward as possible in Infrastructure. We then bind them together using an IoC container to bring the application to life.
