using Microsoft.CSharp;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;


namespace Sisnema
{
    using System;

    class Curso
    {
        public System.String GetNome(System.String nome)
        {
            return nome;
        }
    }
}

namespace Lab.Common.Helpers
{
    public static class CodeDomHelper
    {
        public static CodeCompileUnit GetCompileUnit()
        {
            CodeNamespace sisnemaNamespace = new CodeNamespace("Sisnema");
            sisnemaNamespace.Imports.Add(new CodeNamespaceImport("System"));

            CodeTypeDeclaration cursoType = new CodeTypeDeclaration("Curso");

            CodeMemberMethod getNome = new CodeMemberMethod
            {
                Name = "GetNome",
                ReturnType = new CodeTypeReference("System.String"),
                Attributes = MemberAttributes.Public
            };

            getNome.Parameters.Add(new CodeParameterDeclarationExpression("System.String", "nome"));
            getNome.Statements.Add(new CodeMethodReturnStatement(new CodeArgumentReferenceExpression("nome")));
            
            cursoType.Members.Add(getNome);

            sisnemaNamespace.Types.Add(cursoType);

            CodeCompileUnit codeUnit = new CodeCompileUnit();
            codeUnit.Namespaces.Add(sisnemaNamespace);

            return codeUnit;
        }

        public static void GenerateAssembly(CodeCompileUnit codeCompileUnit)
        {
            CSharpCodeProvider provider = new CSharpCodeProvider();

            CompilerParameters compilerSettings = new CompilerParameters();

            compilerSettings.ReferencedAssemblies.Add("System.dll");

            compilerSettings.OutputAssembly = "Sisnema.dll";
            //compilerSettings.GenerateExecutable = true;

            var compilationResults = provider.CompileAssemblyFromDom(compilerSettings, codeCompileUnit);

            foreach (var error in compilationResults.Errors)
            {
                var errorMessage = error.ToString();
            }
        }

        public static void GenerateFile(CodeCompileUnit codeCompileUnit)
        {
            using (StreamWriter stream = new StreamWriter("SisnemaProgram.cs"))
            {
                using (IndentedTextWriter textWriter = new IndentedTextWriter(stream))
                {
                    CodeGeneratorOptions options = new CodeGeneratorOptions();

                    options.BlankLinesBetweenMembers = true;

                    using (CSharpCodeProvider provider = new CSharpCodeProvider())
                    {
                        provider.GenerateCodeFromCompileUnit(codeCompileUnit, textWriter, options);
                    }

                    textWriter.Close();
                }
                stream.Close();
            }
        }
    }
}
