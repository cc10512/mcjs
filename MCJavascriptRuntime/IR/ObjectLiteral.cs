// --~--~--~--~----~--~--~--~----~--~--~--~----~--~--~--~----~--~--~--~--
// Copyright (c) [2010-2014] The Regents of the University of California
// All rights reserved.
// Redistribution and use in source and binary forms, with or without modification, are permitted (subject to the limitations in the disclaimer below) provided that the following conditions are met:
// * Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
// * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
// * Neither the name of The Regents of the University of California nor the project name nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
// NO EXPRESS OR IMPLIED LICENSES TO ANY PARTY'S PATENT RIGHTS ARE GRANTED BY THIS LICENSE. THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
// --~--~--~--~----~--~--~--~----~--~--~--~----~--~--~--~----~--~--~--~--
﻿using System;
using System.Collections.Generic;

using m.Util.Diagnose;

namespace mjr.IR
{
  public partial class ObjectLiteral : Literal
  {
    public List<PropertyAssignment> Properties { get; private set; }

    public ObjectLiteral(List<PropertyAssignment> properties, int offset = 0)
    {
      Properties = properties;// new List<PropertyDeclarationExpression>();
      SourceOffset = offset;
    }

    //public override bool Replace(Node oldValue, Node newValue)
    //{
    //  for (var i = 0; i < Properties.Count; ++i)
    //  {
    //    if (Properties[i].Replace(oldValue, newValue))
    //      return true;
    //  }
    //  return base.Replace(oldValue, newValue);
    //}

    public override string ToString()
    {
      return string.Format("{{ {0} }}", string.Join(", ", Properties));
    }

    [System.Diagnostics.DebuggerStepThrough]
    public override void Accept(INodeVisitor visitor)
    {
      visitor.Visit(this);
    }

    //internal void Push(PropertyDeclarationExpression propertyExpression)
    //{
    //  if (propertyExpression.Name == null)
    //  {
    //    propertyExpression.Name = propertyExpression.Mode.ToString().ToLower();
    //    propertyExpression.Mode = PropertyExpressionType.Data;
    //  }
    //  if (Values.ContainsKey(propertyExpression.Name))
    //  {
    //    PropertyDeclarationExpression exp = Values[propertyExpression.Name] as PropertyDeclarationExpression;
    //    if (exp == null)
    //      Trace.Fail("A property cannot be both an accessor and data");
    //    switch (propertyExpression.Mode)
    //    {
    //      case PropertyExpressionType.Data:
    //        if (propertyExpression.Mode == PropertyExpressionType.Data)
    //          Values[propertyExpression.Name] = propertyExpression.Expression;
    //        else
    //          Trace.Fail("A property cannot be both an accessor and data");
    //        break;
    //      case PropertyExpressionType.Get:
    //        exp.GetFunction = propertyExpression.GetFunction;
    //        break;
    //      case PropertyExpressionType.Set:
    //        exp.SetFunction = propertyExpression.SetFunction;
    //        break;
    //    }
    //  }
    //  else
    //  {
    //    Values.Add(propertyExpression.Name, propertyExpression);
    //    switch (propertyExpression.Mode)
    //    {
    //      case PropertyExpressionType.Data:
    //        Values[propertyExpression.Name] = propertyExpression;
    //        break;
    //      case PropertyExpressionType.Get:
    //        //propertyExpression.SetGet(propertyExpression);
    //        break;
    //      case PropertyExpressionType.Set:
    //        //propertyExpression.SetSet(propertyExpression);
    //        break;
    //    }
    //  }
    //}
  }
}
