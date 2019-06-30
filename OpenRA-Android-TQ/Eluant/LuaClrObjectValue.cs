//
// LuaClrObjectValue.cs
//
// Authors:
//       Chris Howie <me@chrishowie.com>
//       Tom Roostan <RoosterDragon@outlook.com>
//
// Copyright (c) 2013 Chris Howie
// Copyright (c) 2015 Tom Roostan
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Linq;
using Eluant.ObjectBinding;

namespace Eluant
{
    public abstract class LuaClrObjectValue : LuaValueType, IClrObject
    {
        public object ClrObject { get; private set; }

        public LuaClrObjectValue(object obj)
        {
            ClrObject = obj;
        }

        public override bool ToBoolean()
        {
            return ClrObject != null;
        }

        public override double? ToNumber()
        {
            return null;
        }

        public override string ToString()
        {
            return string.Format("[{0}: ClrObject={1}]", GetType().Name, ClrObject);
        }

        internal abstract object BackingCustomObject { get; }

        internal abstract MetamethodAttribute[] BackingCustomObjectMetamethods(LuaRuntime runtime);

        static internal MetamethodAttribute[] Metamethods(Type backingCustomObjectType)
        {
            return backingCustomObjectType.GetInterfaces()
                .SelectMany(iface => iface.GetCustomAttributes(typeof(MetamethodAttribute), false).Cast<MetamethodAttribute>())
                .ToArray();
        }

        internal override object ToClrType(Type type)
        {
            if (type == null) { throw new ArgumentNullException("type"); }

            if (ClrObject == null) {
                if (!type.IsValueType || (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))) {
                    return null;
                }
            } else {
                if (type.IsAssignableFrom(ClrObject.GetType())) {
                    return ClrObject;
                }
            }

            return base.ToClrType(type);
        }
    }
}

