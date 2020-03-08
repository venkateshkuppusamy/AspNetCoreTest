
#Project for BasicAuthentication for AspNetCore API



#What is Basic Authentication?
 Basic Authentication is a Simple authentication Scheme build into Http Protocol. Basic authentication allows browsers / api consumers to provide resources based on 
 credentials(username and password). Its doesnt required, cookies, sessions or login pages.

#How it works?
 The Http request should have the header "Authorization" containing the "Basic {Base64EncodedStringContingUserNameAndPassword}". eg "Authorization: Basic YWRtaW46cEBzNXcwcmQ=".
 Base64String is easily encoded, so the request should be HTTS/SSL for better security.
 At the API site use a middleware or Filter to authenticate the request and then send response for forbid the request.

#AspNetCore Basic Authentication Using Filter
 1. Create a AuthenticationFilter    - a class which implement IAuthorizationFilter, eg., BasicAuthFilter. This is where you reterive the headers data from request.
 2. Create a AuthenticationAttribute - a class which can be used to decorate controllers, action methods.
 3. Add Authentication Attribute to the controller or action method. Alternatively you can add at the global level in startup Configure Services method.
 4. Futher you can add logic within Authentication Filter to exclue action methods which have AllowAnnonymous attribute added.