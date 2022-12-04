# NicosiaAssingment

<b>How to run: </b>
1) Perform migrations : `dotnet ef database update --project NicosiaAssingment.DataAccess --startup-project NicosiaAssingment`
2) Run the app and open `/index.html` 
3) Get JWT token by calling `/api/v1/auth/authenticate` For that use the following credentials: 
    * john-petrucci@nicosia.com     | `qwe123`       (student account)
    * max-well@nicosia.com          | `asd123`       (student account)
    * brian-dough@nicosia.com       | `zxc123`       (student account)
    * satoshi-nakamoto@nicosia.com  | `bit123`       (lecturer account)
    * john-lock@nicosia.com         | `loc123`       (lecturer account)
4) Use the newly generated JWT token when interacting with the API (a token will expire in 15 minutes. Expiration timeout can be changed in the appsettings.json)

<b>Database schema: </b>

![DBSchema](https://github.com/BalanceBalls/NicosiaAssingment/blob/master/DBSchema.png)