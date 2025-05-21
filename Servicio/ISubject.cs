﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio
{
    public interface ISubject
    {
        void Agregar(IObserver observer);
        void Quitar(IObserver observer);
        void Notificar();
    }
}
