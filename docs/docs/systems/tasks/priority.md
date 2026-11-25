# Priority (foreground) tasks

A priority task is one that is required for the user to be able to continue. This involves
blocking user input until the process has been completed.
This typically involves an undismissable dialog with a progress bar and a cancel button.
A priority task should be avoided unless **absolutely neccecary**. Updating certain data,
or other minimal tasks should be done as [background tasks](background.md) instead.