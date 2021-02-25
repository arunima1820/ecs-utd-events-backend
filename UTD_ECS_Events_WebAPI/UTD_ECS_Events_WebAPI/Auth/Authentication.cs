﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//using FirebaseAdmin;
//using FirebaseAdmin.Auth;

using Firebase.Auth;


namespace UTD_ECS_Events_WebAPI.Auth
{
    public class Authentication
    {
        private static async Task Login()
        {
            string apiKey = "AIzaSyDB2ETPVZ60rwOvmvmJqPiCXjHnkBSut9o";  // found under project setting
            var obj = new FirebaseAuthProvider(new FirebaseConfig(apiKey));
            string email = "utdecsevents@google.com";
            string password = "Pass1234";
            var auth = await obj.SignInWithEmailAndPasswordAsync(email, password);   // line 161 of https://github.com/step-up-labs/firebase-authentication-dotnet/blob/master/src/Firebase.Auth/FirebaseAuthProvider.cs
        }



        /// <summary>
        /// Using the provided email and password, get the firebase auth with token and basic user credentials.
        /// </summary>
        /// <param name="email"> The email. </param>
        /// <param name="password"> The password. </param>
        /// <param name="tenantId"></param>
        /// <returns> The <see cref="FirebaseAuthLink"/>. </returns>
    }
}
