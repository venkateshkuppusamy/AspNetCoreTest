
#Project for BasicAuthentication for AspNetCore API



#What is Basic Authentication?
 Basic Authentication is a Simple authentication Scheme build into Http Protocol. Basic authentication allows browsers / api consumers to provide resources based on 
 credentials(username and password). Its doesnt required, cookies, sessions or login pages.

#How it works?
 The Http request should have the header "Authorization" containing the "Basic {Base64EncodedStringContingUserNameAndPassword}". eg "Authorization: Basic YWRtaW46cEBzNXcwcmQ=".
 Base64String is easily encoded, so the request should be HTTS/SSL for better security.
 At the API site use a middleware or Filter to authenticate the request and then send response for forbid the request.

#AspNetCore Basic Authentication Using MiddleWare
 1. Create a Middle ware class using a "Middleware Class" template -- Implement the method "public Task Invoke(HttpContext context)". On successfull authentication, the
 next middleware in the request pipeline is executed. On Failed authentication, response with status code 401 UnAuthorized is sent. 
 2. This approach authenticates the request event before Controller are created. All request are authenticated in this middleware.

#Drawbacks of this approach or Need Improvement.
 There is no clean solution to black list the action methods from being authenticated.

