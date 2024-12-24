using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Reflection;
using System.IO;

namespace WhatAmI.Content.src.orb
{
    internal class Orb
    {

        internal void testHello()
        {
            Console.WriteLine("Hello!");
        }
        internal object? hello()
        {
            string code = @"
            using System;
            using WhatAmI.Content.src.terminal;
            using WhatAmI.Content.src.core;

            
            internal class DynamicClass : UD
            {
                Terminal t;
                public string SayHello()
                {
                    return(""Hello, World!"");
                }

                internal override void Update(){}
                internal override void Draw(){}
                
            }";

            var syntaxTree = CSharpSyntaxTree.ParseText(code);

            var references = new[]
            {
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location), // mscorlib or System.Private.CoreLib
                MetadataReference.CreateFromFile(typeof(Console).Assembly.Location), // System.Console
                MetadataReference.CreateFromFile(Path.Combine(Path.GetDirectoryName(typeof(object).Assembly.Location),"System.Runtime.dll")),
                MetadataReference.CreateFromFile(Assembly.GetExecutingAssembly().Location) // Current assembly
            };


            // Create a compilation
            var compilation = CSharpCompilation.Create(
                "DynamicAssembly",
                new[] { syntaxTree },
                references,
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
            );

            // Compile to an in-memory assembly
            using var memoryStream = new MemoryStream();
            var result = compilation.Emit(memoryStream);

            if (!result.Success)
            {
                // Print any compilation errors
                foreach (var diagnostic in result.Diagnostics)
                {
                    Console.WriteLine(diagnostic.ToString());
                }
                return null;
            }

            // Load the compiled assembly
            memoryStream.Seek(0, SeekOrigin.Begin);
            var assembly = Assembly.Load(memoryStream.ToArray());

            // Get the type of the dynamic class
            var dynamicType = assembly.GetType("DynamicClass");

            // Create an instance of the dynamic class
            var instance = Activator.CreateInstance(dynamicType);

            // Invoke the SayHello method
            var method = dynamicType.GetMethod("SayHello");
            return method.Invoke(instance, null);


        }
    }
}
