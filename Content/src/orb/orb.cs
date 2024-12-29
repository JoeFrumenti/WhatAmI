using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Reflection;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace WhatAmI.Content.src.orb
{
    internal class Orb
    {

        internal void testHello()
        {
            Console.WriteLine("Hello!");
        }

        internal object? compileFunction(string code)
        {

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

        internal object? compileObject(string code, Texture2D tex)
        {
            //Console.Write(code);
            var syntaxTree = CSharpSyntaxTree.ParseText(code);
            string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string monoGamePath = @"C:\Users\joefr\.nuget\packages\monogame.framework.desktopgl\3.8.2.1105\lib\net8.0\MonoGame.Framework.dll";
            if (!File.Exists(monoGamePath))
            {
                Console.WriteLine("Error: MonoGame.Framework.dll not found!");
                return null;
            }

            

            var references = new[]
            {
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location), // mscorlib or System.Private.CoreLib
                MetadataReference.CreateFromFile(typeof(Console).Assembly.Location), // System.Console
                MetadataReference.CreateFromFile(Path.Combine(Path.GetDirectoryName(typeof(object).Assembly.Location),"System.Runtime.dll")),
                MetadataReference.CreateFromFile(Assembly.GetExecutingAssembly().Location), // Current assembly
                MetadataReference.CreateFromFile(monoGamePath)
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


            object[] constructorArgs = { tex, new Vector2(100, 100) }; // Replace with your actual parameter values
            if (dynamicType == null)
            {
                Console.WriteLine("dynamicType is null. The type 'DynamicClass' was not found in the assembly.");
            }

            var constructors = dynamicType.GetConstructors();
            foreach (var ctor in constructors)
            {
                Console.WriteLine(ctor);
            }

            // Create an instance of the dynamic class
            var instance = Activator.CreateInstance(dynamicType, constructorArgs);

            return instance;


        }

        internal object? castSorcery(string filePath,Texture2D tex)
        {
            string sorcery = "";
            try
            {
                // Read the entire content of the file into a string
                sorcery = File.ReadAllText(filePath);                // Output the content to the console
                //Console.WriteLine(sorcery);
            }
            catch (Exception ex)
            {
                // Handle exceptions, e.g., file not found or access denied
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return compileObject(sorcery, tex);
        }

        internal object? makePlayer(Texture2D tex)
        {
            string code = @"
            using System;
            using WhatAmI.Content.src.terminal;
            using WhatAmI.Content.src.core;

            
            internal class DynamicClass : UD
            {
                

                internal override void Update(){Console.WriteLine(""AAA"");}


                internal override void Draw(){Console.WriteLine(""BBB"");}
                
            }";
            return compileObject(code,tex);
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
            return compileFunction(code);
        }
    }
}
