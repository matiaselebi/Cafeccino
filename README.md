# Sistema de Gestión para Cafeccino ☕

El objetivo principal del sistema es **modernizar la gestión del negocio** de Cafeccino. Actualmente, la gestión de ventas, compras, clientes y productos se realiza manualmente en cuadernos, lo que dificulta el acceso y análisis de la información.

La implementación de este sistema busca **agilizar y optimizar el trabajo de los empleados** (vendedores, compradores, almacenistas, administradores), **mejorar la experiencia del cliente**, proporcionar un **control preciso del stock** y facilitar el **seguimiento de clientes** para la toma de decisiones.

El sistema está diseñado para ser **fácil de entender y usar**, ser **escalable**, ofrecer una **interfaz amigable** y cumplir con **estándares de seguridad y buenas prácticas de programación**.

---

## ⚙️ Funcionalidades Principales

- **Gestión de Ventas**: Registro de ventas, emisión de facturas, selección de productos, cobro y alta de clientes.
- **Gestión de Compras**: Alta de proveedores, ingreso de productos, órdenes de compra, recepción y facturación.
- **Maestros**: Gestión de productos, clientes y proveedores con serialización/deserialización XML.
- **Administrador**: Gestión de usuarios, perfiles, bitácora, respaldos y permisos.
- **Usuario**: Login, logout, cambio de contraseña e idioma.
- **Reportes**: Generación de reportes PDF de ventas y reportes inteligentes.
- **Ayuda**: Manual de usuario y ayuda en línea.

---

## 🔐 Usuario por defecto

Este usuario tiene permisos de administrador:

- **Usuario**: `mati`  
- **Contraseña**: `aaaa1111`  

---

## 🧠 Aspectos Técnicos y de Seguridad

- **Arquitectura de Capas**: BE, BLL, DAL, Servicios.
- **SHA-256**: Encriptación irreversible para contraseñas.
- **AES-256**: Encriptación reversible de datos sensibles como direcciones.
- **Dígito Verificador (DVH y DVV)**: Para integridad de datos.
- **Bitácora de eventos** y triggers para auditar y registrar cambios.

---

## 🧩 Tecnologías y Dependencias

- **Lenguaje**: C#
- **Framework**: .NET Framework 4.7.2
- **Base de Datos**: SQL Server Management Studio 19
- **Paquetes NuGet utilizados**:
  - BouncyCastle.Cryptography: Para encriptación avanzada (AES-256).
  - iTextSharp: Para generación de reportes en formato PDF.
- **Requisitos Mínimos**:
  - CPU: 1.5 GHz
  - RAM: 2 GB
  - SO: Windows XP o superior

> ⚠️ Si usás reportes PDF, puede ser necesario tener Crystal Reports instalado.

---

## 🛠️ Instalación y Restauración de la Base de Datos

1. Abrí SQL Server Management Studio.
2. Creá una nueva base de datos llamada **Cafeccino Base de Datos**.
3. Clic derecho sobre la nueva base de datos > "New Query".
4. Abrí el archivo `.sql` incluido en este repositorio (por ejemplo: `Cafeccino_Base_de_Datos.sql`).
5. Ejecutá el script (F5).
6. ¡Listo! La base de datos estará configurada con datos iniciales.

---

## 📄 Documentación Incluida

- **Manual de Usuario**: Paso a paso del uso del sistema.
- **Guías de Instalación y Configuración**: Documentos técnicos y prácticos.
- **Ayuda en Línea**: Preguntas frecuentes.

---

## 📝 Licencia

Este proyecto está licenciado bajo la Licencia MIT.  
Podés ver el archivo [`LICENSE`](./LICENSE) para más detalles.

---

## 💬 Contacto

Para dudas o sugerencias, podés abrir un issue o comunicarte directamente a través del repositorio.
