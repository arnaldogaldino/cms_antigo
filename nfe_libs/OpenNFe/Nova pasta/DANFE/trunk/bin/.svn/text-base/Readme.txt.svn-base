-----------------------------------------------------------------------------
OpenSSL v1.0.0c, Precompiled Binaries for Win32
-----------------------------------------------------------------------------

Released Date:  December 06, 2010

Created by:     Arvid Winkelsdorf (digivendo GmbH, www.digivendo.com)
                for The Indy Project (www.indyproject.org)

Dependencies:   Requires Indy SVN (10.5.5+)

THIS SOFTWARE IS PROVIDED BY THE INDY PROJECT 'AS IS'. Please see the
OpenSSL license terms in the file "OpenSSL License.txt".

PLEASE CHECK IF YOU NEED TO COMPLY WITH EXPORT RESTRICTIONS FOR CRYPTOGRAPHIC
SOFTWARE AND / OR PATENTS (WHERE APPLICABLE).

Build Informations
------------------

Built with:     Microsoft Visual C++ 2010 Express Edition
                Strawberry Perl v5.12.1.0 built for MSWin32-x86-multi-thread
                The Netwide Assembler (NASM) v2.09.04

Build commands: perl configure VC-WIN32
                ms\do_nasm
                adjusted ms\ntdll.mak (replace "/MD" with "/MT" for static linking)
                adjusted ms\version32.rc (Indy Information inserted)
                nmake -f ms\ntdll.mak
                editbin.exe /rebase:base=0×11000000 libeay32.dll
                editbin.exe /rebase:base=0×12000000 ssleay32.dll

Test command:   nmake -f ms\ntdll.mak test

Comment:
  The libraries are compiled *without* dependencies to the MS VC++ 2010
  runtime libraries.

----------------------------------------------------------------------------- 