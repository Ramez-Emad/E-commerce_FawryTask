using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_FawryTask.Exceptions;
public sealed class InsufficientBalanceException() : Exception("Insufficient balance.")
{
}
