# Extension Methods
                .RegisterPages(myAssembly)
                .RegisterPageRoutes(myAssembly)
                .RegisterViewModels(myAssembly)
                .RegisterPlatformServices()
                .RegisterLocalServices()
                .RegisterViewModels(typeof(NotesViewModel).Assembly)
                .RegisterIOC()

Service Registrations are broken down into a few segments and done via naming convention and by assembly. Of course you can register additional items by hand but the provided patterns are as follows:

# RegisterPages(assembly)
Registers ALL creatable types within the assembly ending in "Page" as TRANSIENT.

# RegisterViewModels(assembly)
Registers ALL creatable types within the assembly ending in "ViewModel" as TRANSIENT.
In addition, if the ViewModel implements an INTERFACE Of some IBlahViewModel, it will register that as a Transient of that interface.

# RegisterPagesRoutes(assembly)
Register all Pages as Routes with the following pattern. Their Name, and their name without the Page suffix. IE: GamePage would be
Game
GamePage
This obviously only works for simple apps without deep routing.


# RegisterViewModels(assembly)
Registers ALL creatable types within the assembly ending in "ViewModel" as TRANSIENT.
In addition, if the ViewModel implements an INTERFACE Of some IBlahViewModel, it will register that as a Transient of that interface.


# RegisterPlatformServices

Calls the DeviceInstance for the specific platform that registers the device platform registrations (Email, Audio, other platform services)

# RegisterLocalServices
Shared Services for the app that are not platform specific.

# RegisterIOC
Adds the IOC container as a passable interface.

