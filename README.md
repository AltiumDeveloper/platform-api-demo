# Altium 365 API Demo


A365 workspace queries powered by Altium 365 API.

Live demo: <TBD>

## How to use

If you have not done this, please enroll at Altium Developer Center.

In order to see anything useful, you also need your Altium Live credentials and
have to be a member of at least one Altium 365 workspace.

The demo requires an access token. Go to Altium Developer Center application details.

Having got a token, copy it to the clipboard and open the app in a browser.
Paste the token at the `Connect` page and click `CONNECT`. The browser keeps
and restores the token on next runs. The token may be used until it expires.

## Features

- Altium 365 hierarchical data tree with some notable branches.
- Example of using various Altium 365 API queries in .NET applications.
- Example of using workspace region specific endpoints.

Data tree structure:

- Shared with Me
    - Projects
- Workspace
    - Projects
        - Design
            - Variants
                - BOM
                - PCB
                - Layers
                - Schematics
        - Releases
            - Variants
                - BOM
                - PCB
                - Schematics
        - Collaboration
            - ECAD
            - MCAD
            - ESD
        - Simulation
            - AnsysEDB
            - PCBEDB
        - Tasks
        - Comments
        - Revisions
    - Library
        - Folders
        - Component Search
        - Component Templates
    - Tasks
    - Users
    - Workflows
    - Configuration
        - Project Templates

## URL parameters

The application may be started with the following parameters:

```
https://web-design-demo.nexar.com?api=...&token=...&workspace=...
```

- `api`

    The Altium 365 API GraphQL endpoint, <https://eur.365.altium.com/napi/gateway/graphql>

- `token`

    The Altium access token to use and skip the connect page.

- `workspace`

    The pinned workspace URL.
    Its content is shown instead of all workspaces.

## Building blocks

[Blazor]: https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor
[MudBlazor]: https://github.com/Garderoben/MudBlazor

The app is built with [Blazor] using [MudBlazor] components.

The Design domain data are provided by Altium 365 API: <https://eur.365.altium.com/napi/gateway/graphql>.
This is the endpoint for GraphQL queries and also the GraphQL IDE "Banana Cake Pop".

The package [HotChocolate StrawberryShake](https://github.com/ChilliCream/hotchocolate)
is used for generating strongly typed C# client code for invoking GraphQL queries.
See the source queries in [Resources](Altium.Client/Resources).

## How to update GraphQL schema

Change to `Altium.Client` and run:

```
dotnet tool restore
dotnet graphql update
```

As a result, the GraphQL schema file `schema.graphql` is updated to the latest.
