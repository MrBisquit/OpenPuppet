# Tasks Overview

There are a few fairly basic rules for the tasks system in OpenPuppet:

- **All** tasks must be cancellable.
- Background tasks shouldn't *massively*\* alter the UI.
    - \* meaning things like loading a layout, or plugin that may shift the layout.
        Things such as previews, icons, or other small details on the screen **do not**
        count as *massively* altering the UI.