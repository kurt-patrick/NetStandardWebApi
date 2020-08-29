This micro project demonstrates how to validate POST and PUT models on actions using custom attributes.

2 examples have been provided:
- ValidateNullModelAttribute: which validates the post/put body is not null
- ValidateModelStateAttribute: which checks ModelState.IsValid is valid

Both examples can be found in the Filters folder
By using atttributes you no longer need to write the same validation logic over and over and over.
It also keep your actions cleaner
