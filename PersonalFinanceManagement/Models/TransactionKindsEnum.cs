﻿/*
 * Personal Finance Management API
 *
 * Personal Finance Management API allows analyze of a client's spending patterns against pre-defined budgets over time 
 *
 * OpenAPI spec version: v1
 * Contact: aleksandar.milosevic@asseco-see.rs
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace PersonalFinanceManagement.Models
{
    /// <summary>
    /// Enumeration that distinguishes between accounting transactions based on their effect on the customer accounts.
    /// </summary>
    /// <value>Enumeration that distinguishes between accounting transactions based on their effect on the customer accounts.</value>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum TransactionKindsEnum
    {
        
       
        dep, wdw, pmt, fee, inc, rev,adj,lnd,lnr,fcx,aop,acl,spl,sal,
       
    }
}
