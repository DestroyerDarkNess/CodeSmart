
Namespace Core.Scintilla

    Public Class LexerWords

#Region " VB "

        Public Shared keywords As String =
   <a>
debug
release
addhandler
addressof
aggregate
alias
and
andalso
ansi
as
assembly
auto
binary
boolean
byref
byte
byval
call
case
catch
cbool
cbyte
cchar
cdate
cdbl
cdec
char
cint
class
clng
cobj
compare
const
continue
csbyte
cshort
csng
cstr
ctype
cuint
culng
cushort
custom
date
decimal
declare
default
delegate
dim
directcast
distinct
do
double
each
else
elseif
end
endif
enum
equals
erase
error
event
exit
explicit
false
finally
for
friend
from
function
get
gettype
getxmlnamespace
global
gosub
goto
group
handles
if
implements
imports
in
inherits
integer
interface
into
is
isfalse
isnot
istrue
join
key
let
lib
like
long
loop
me
mid
mod
module
mustinherit
mustoverride
my
mybase
myclass
namespace
narrowing
new
next
not
nothing
notinheritable
notoverridable
object
of
off
on
operator
option
optional
or
order
orelse
overloads
overridable
overrides
paramarray
partial
preserve
private
property
protected
public
raiseevent
readonly
redim
rem
removehandler
resume
return
sbyte
select
set
shadows
shared
short
single
skip
static
step
stop
strict
string
structure
sub
synclock
take
text
then
throw
to
true
try
trycast
typeof
uinteger
ulong
unicode
until
ushort
using
variant
wend
when
where
while
widening
with
withevents
writeonly
xor
</a>.Value

        Public Shared classnames As String =
    <a>
array
backgroundworker
bitmap
button
checkbox
checkedlistbox
colordialog
combobox
component
contextmenustrip
control
datagridview
dataset
datetime
datetimepicker
dictionary
directorysearcher
errorprovider
eventlog
exception
fileinfo
filesystemwatcher
flowlayoutpanel
form
graphics
groupbox
helpprovider
hscrollbar
iappdomainsetup
iasyncresult
ibindablecomponent
ibuttoncontrol
icloneable
icollectdatta
icollection
icolumnmapping
icolumnmappingcollection
icommandexecutor
icomparable
icomparer
icomponent
icomponenteditorpagesite
icontainercontrol
iconvertible
icurrencymanagerprovider
icustomformatter
idataadapter
idatagridcolumnstyleeditingnotificationservice
idatagrideditingservice
idatagridvieweditingcell
idatagridvieweditingcontrol
idataobject
idataparameter
idataparametercollection
idatareader
idatarecord
idbcommand
idbconnection
idbdataadapter
idbdataparameter
idbtransaction
idevicecontext
idictionary
idictionaryenumerator
idisposable
idroptarget
ienumerable
ienumerator
iequalitycomparer
iequatable
ifeaturesupport
ifilereaderservice
iformatprovider
iformattable
iformatter
igroupping
ihashcodeprovider
ilist
ilookup
image
imagelist
imessagefilter
inotifypropertychanged
int16
int32
int64
iobservable
iobserver
iorderedenumerable
iorderedqueryable
iqueryable
iqueryprovider
iserializable
iserviceprovider
iset
istructuralcomparable
istructuralequatable
itablemapping
itablemappingcollection
iwin32window
iwindowtarget
label
linklabel
list
listbox
listview
maskedtextbox
menustrip
messagequeue
monthcalendar
nativewindow
notifyicon
numericupdown
openfiledialog
panel
pen
performancecounter
picturebox
point
pointf
printdialog
printdocument
process
progressbar
propertygrid
radiobutton
readonlycollection
rectangle
rectanglef
regex
richtextbox
savefiledialog
serialport
servicecontroller
size
sizef
solidbrush
splitcontainer
statusstrip
system
tabcontrol
tablelayoutpanel
textbox
timer
toolstrip
toolstripcontainer
tooltip
trackbar
type
uint16
uint32
uint64
vscrollbar
webbrowser
</a>.Value

        Public Shared literals As String =
    <a>
!
#
%
@
&amp;
i
d
f
l
r
s
ui
ul
us
</a>.Value

        Public Shared Function GetVBAutoCompleteList() As String()
            Dim LcalVal As String() = Nothing

        End Function


#End Region
     

    End Class

End Namespace

