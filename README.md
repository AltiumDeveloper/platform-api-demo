# Altium 365 API Demo


Altium 365 workspace queries powered by [Altium 365 API](https://www.altium.com/documentation/altium-developer-center/altium-365/api).

Live demo: https://a365-api-demo.intdev.altium.com/

## How to use

If you have not done this, please enrol at [Altium Developer Center](https://developer.altium.com/).
In order to see anything useful, you also need to be a member of at least one Altium 365 workspace.

Please see [Altium 365 API Quick Start Guide](https://www.altium.com/documentation/altium-developer-center/quick-starts/365-api)
for details on retrieving Altium 365 API access token.

Having got a token, copy it to the clipboard and open the app in a browser.
Paste the token at the `Connect` page and click `CONNECT`. The browser keeps
and restores the token on next runs. The token may be used until it expires.

## Features

- Altium 365 hierarchical data tree with some notable branches.
- Example of using various Altium 365 API queries in .NET applications.
- Example of using workspace region-specific endpoints.

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
https://a365-api-demo.intdev.altium.com?api=...&token=...&workspace=...
```

- `api`

    The Altium 365 API GraphQL endpoint

- `token`

    The Altium access token to use and skip the connect page.

- `workspace`

    The pinned workspace URL.
    Its content is shown instead of all workspaces.

## Building blocks

[Blazor]: https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor
[MudBlazor]: https://github.com/Garderoben/MudBlazor
[Altium 365 API]: https://www.altium.com/documentation/altium-developer-center/altium-365/api

The app is built with [Blazor] using [MudBlazor] components.

The Design domain data are provided by [Altium 365 API].

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
