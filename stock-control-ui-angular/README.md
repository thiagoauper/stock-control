# StockControlUi

This project was generated using [Angular CLI](https://github.com/angular/angular-cli) version 19.2.7.

## Development server

To start a local development server, run:

```bash
ng serve
```

Once the server is running, open your browser and navigate to `http://localhost:4200/`. The application will automatically reload whenever you modify any of the source files.

## Code scaffolding

Angular CLI includes powerful code scaffolding tools. To generate a new component, run:

```bash
ng generate component component-name
```

For a complete list of available schematics (such as `components`, `directives`, or `pipes`), run:

```bash
ng generate --help
```

## Building

To build the project run:

```bash
ng build
```

This will compile your project and store the build artifacts in the `dist/` directory. By default, the production build optimizes your application for performance and speed.

## Running unit tests

To execute unit tests with the [Karma](https://karma-runner.github.io) test runner, use the following command:

```bash
ng test
```

## Running end-to-end tests

For end-to-end (e2e) testing, run:

```bash
ng e2e
```

Angular CLI does not come with an end-to-end testing framework by default. You can choose one that suits your needs.

## Additional Resources

For more information on using the Angular CLI, including detailed command references, visit the [Angular CLI Overview and Command Reference](https://angular.dev/tools/cli) page.


# PROJECT STRUCTURE

Created under the **src\app\modules** folder, it should have the following types of modules:

  - **Core**: eager loaded, it contains logic  which's used across the whole app only once, therefore it provides singleton services, components, etc.

  - **Features**: it contains lazy loaded modules which represent each feature of the app.

  - **Shared**: eager loaded, it contains logic which's used across the whole app as many times as needed, such as components, pipes, directives, etc.

**IMPORTANT**

- Everything should be created under this structure.

- Every module should follow this proposed structure:

    *\Module X*
    - \abstract (contains all abstract classes)
    - \classes (contains all classes other than models and abstract)
    - \components
    - \constants
    - \directives
    - \enumerators
    - \guards
    - \interceptors
    - \interfaces
    - \models (used for transferring data from and to APIs, for example)
    - \pages (Page is a component which is **only** used as a target to a route. Its selector is never used!)
    - \pipes
    - \services (Make sure each service is **only** provided within the module it belongs, i.e., do not use `providedIn: 'root'` in its declaration. Declare it in the list of **providers** contained within its respective module.)
    - \modules (Depending on the case, a module could contain submodules. They should be created under this folder and follow the proposed structure recursively.)