using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.SmartEnum;

namespace Clean.Architecture.Core.PersonAggregate;
public class PersonStatus : SmartEnum<PersonStatus>
{
  public static readonly PersonStatus Disabled = new(nameof(Disabled), 1);
  public static readonly PersonStatus Enabled = new(nameof(Enabled), 2);
  public static readonly PersonStatus Blocked = new(nameof(Blocked), 3);

  protected PersonStatus(string name, int value) : base(name, value) { }
}
