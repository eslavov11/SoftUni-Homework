#
# Generated Makefile - do not edit!
#
# Edit the Makefile in the project folder instead (../Makefile). Each target
# has a -pre and a -post target defined where you can add customized code.
#
# This makefile implements configuration specific macros and targets.


# Environment
MKDIR=mkdir
CP=cp
GREP=grep
NM=nm
CCADMIN=CCadmin
RANLIB=ranlib
CC=gcc
CCC=g++
CXX=g++
FC=gfortran
AS=as

# Macros
CND_PLATFORM=MinGW-Windows
CND_DLIB_EXT=dll
CND_CONF=Debug
CND_DISTDIR=dist
CND_BUILDDIR=build

# Include project Makefile
include Makefile

# Object Directory
OBJECTDIR=${CND_BUILDDIR}/${CND_CONF}/${CND_PLATFORM}

# Object Files
OBJECTFILES= \
	${OBJECTDIR}/Problem\ 01.\ Reverse\ String.o \
	${OBJECTDIR}/Problem\ 02.\ String\ Length.o \
	${OBJECTDIR}/Problem\ 03.\ Series\ of\ Letters.o \
	${OBJECTDIR}/Problem\ 04.\ Count\ Substring\ Occurrences.o \
	${OBJECTDIR}/Problem\ 05.\ Text\ Filter.o \
	${OBJECTDIR}/Problem\ 06.\ Palindromes.o \
	${OBJECTDIR}/Problem\ 07.\ Implement\ a\ String\ Copy\ Function.o \
	${OBJECTDIR}/Problem\ 08.\ Implement\ a\ String\ Concatenation\ Function.o \
	${OBJECTDIR}/Problem\ 09.\ Implement\ a\ Word\ Count\ function.o \
	${OBJECTDIR}/Problem\ 10.\ Implement\ a\ String\ Length\ function.o \
	${OBJECTDIR}/Problem\ 11.\ Implement\ a\ String\ Search\ function.o \
	${OBJECTDIR}/Problem\ 12.\ Implement\ a\ Substring\ function.o \
	${OBJECTDIR}/Problem\ 13.\ Read\ Line\ Function.o \
	${OBJECTDIR}/Problem\ 14.\ Matrix\ of\ Palindromes.o \
	${OBJECTDIR}/Problem\ 15.\ Remove\ Names.o \
	${OBJECTDIR}/Problem\ 16.\ Longest\ Word\ in\ a\ Text.o \
	${OBJECTDIR}/Problem\ 17.\ XML\ Parser.o \
	${OBJECTDIR}/Problem\ 18.\ Longest\ Area\ in\ Array.o


# C Compiler Flags
CFLAGS=

# CC Compiler Flags
CCFLAGS=
CXXFLAGS=

# Fortran Compiler Flags
FFLAGS=

# Assembler Flags
ASFLAGS=

# Link Libraries and Options
LDLIBSOPTIONS=

# Build Targets
.build-conf: ${BUILD_SUBPROJECTS}
	"${MAKE}"  -f nbproject/Makefile-${CND_CONF}.mk ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_9_c_characters_and_strings.exe

${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_9_c_characters_and_strings.exe: ${OBJECTFILES}
	${MKDIR} -p ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}
	${LINK.c} -o ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_9_c_characters_and_strings ${OBJECTFILES} ${LDLIBSOPTIONS}

.NO_PARALLEL:${OBJECTDIR}/Problem\ 01.\ Reverse\ String.o
${OBJECTDIR}/Problem\ 01.\ Reverse\ String.o: Problem\ 01.\ Reverse\ String.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 01.\ Reverse\ String.o Problem\ 01.\ Reverse\ String.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 02.\ String\ Length.o
${OBJECTDIR}/Problem\ 02.\ String\ Length.o: Problem\ 02.\ String\ Length.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 02.\ String\ Length.o Problem\ 02.\ String\ Length.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 03.\ Series\ of\ Letters.o
${OBJECTDIR}/Problem\ 03.\ Series\ of\ Letters.o: Problem\ 03.\ Series\ of\ Letters.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 03.\ Series\ of\ Letters.o Problem\ 03.\ Series\ of\ Letters.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 04.\ Count\ Substring\ Occurrences.o
${OBJECTDIR}/Problem\ 04.\ Count\ Substring\ Occurrences.o: Problem\ 04.\ Count\ Substring\ Occurrences.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 04.\ Count\ Substring\ Occurrences.o Problem\ 04.\ Count\ Substring\ Occurrences.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 05.\ Text\ Filter.o
${OBJECTDIR}/Problem\ 05.\ Text\ Filter.o: Problem\ 05.\ Text\ Filter.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 05.\ Text\ Filter.o Problem\ 05.\ Text\ Filter.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 06.\ Palindromes.o
${OBJECTDIR}/Problem\ 06.\ Palindromes.o: Problem\ 06.\ Palindromes.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 06.\ Palindromes.o Problem\ 06.\ Palindromes.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 07.\ Implement\ a\ String\ Copy\ Function.o
${OBJECTDIR}/Problem\ 07.\ Implement\ a\ String\ Copy\ Function.o: Problem\ 07.\ Implement\ a\ String\ Copy\ Function.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 07.\ Implement\ a\ String\ Copy\ Function.o Problem\ 07.\ Implement\ a\ String\ Copy\ Function.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 08.\ Implement\ a\ String\ Concatenation\ Function.o
${OBJECTDIR}/Problem\ 08.\ Implement\ a\ String\ Concatenation\ Function.o: Problem\ 08.\ Implement\ a\ String\ Concatenation\ Function.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 08.\ Implement\ a\ String\ Concatenation\ Function.o Problem\ 08.\ Implement\ a\ String\ Concatenation\ Function.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 09.\ Implement\ a\ Word\ Count\ function.o
${OBJECTDIR}/Problem\ 09.\ Implement\ a\ Word\ Count\ function.o: Problem\ 09.\ Implement\ a\ Word\ Count\ function.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 09.\ Implement\ a\ Word\ Count\ function.o Problem\ 09.\ Implement\ a\ Word\ Count\ function.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 10.\ Implement\ a\ String\ Length\ function.o
${OBJECTDIR}/Problem\ 10.\ Implement\ a\ String\ Length\ function.o: Problem\ 10.\ Implement\ a\ String\ Length\ function.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 10.\ Implement\ a\ String\ Length\ function.o Problem\ 10.\ Implement\ a\ String\ Length\ function.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 11.\ Implement\ a\ String\ Search\ function.o
${OBJECTDIR}/Problem\ 11.\ Implement\ a\ String\ Search\ function.o: Problem\ 11.\ Implement\ a\ String\ Search\ function.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 11.\ Implement\ a\ String\ Search\ function.o Problem\ 11.\ Implement\ a\ String\ Search\ function.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 12.\ Implement\ a\ Substring\ function.o
${OBJECTDIR}/Problem\ 12.\ Implement\ a\ Substring\ function.o: Problem\ 12.\ Implement\ a\ Substring\ function.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 12.\ Implement\ a\ Substring\ function.o Problem\ 12.\ Implement\ a\ Substring\ function.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 13.\ Read\ Line\ Function.o
${OBJECTDIR}/Problem\ 13.\ Read\ Line\ Function.o: Problem\ 13.\ Read\ Line\ Function.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 13.\ Read\ Line\ Function.o Problem\ 13.\ Read\ Line\ Function.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 14.\ Matrix\ of\ Palindromes.o
${OBJECTDIR}/Problem\ 14.\ Matrix\ of\ Palindromes.o: Problem\ 14.\ Matrix\ of\ Palindromes.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 14.\ Matrix\ of\ Palindromes.o Problem\ 14.\ Matrix\ of\ Palindromes.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 15.\ Remove\ Names.o
${OBJECTDIR}/Problem\ 15.\ Remove\ Names.o: Problem\ 15.\ Remove\ Names.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 15.\ Remove\ Names.o Problem\ 15.\ Remove\ Names.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 16.\ Longest\ Word\ in\ a\ Text.o
${OBJECTDIR}/Problem\ 16.\ Longest\ Word\ in\ a\ Text.o: Problem\ 16.\ Longest\ Word\ in\ a\ Text.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 16.\ Longest\ Word\ in\ a\ Text.o Problem\ 16.\ Longest\ Word\ in\ a\ Text.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 17.\ XML\ Parser.o
${OBJECTDIR}/Problem\ 17.\ XML\ Parser.o: Problem\ 17.\ XML\ Parser.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 17.\ XML\ Parser.o Problem\ 17.\ XML\ Parser.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 18.\ Longest\ Area\ in\ Array.o
${OBJECTDIR}/Problem\ 18.\ Longest\ Area\ in\ Array.o: Problem\ 18.\ Longest\ Area\ in\ Array.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 18.\ Longest\ Area\ in\ Array.o Problem\ 18.\ Longest\ Area\ in\ Array.c

# Subprojects
.build-subprojects:

# Clean Targets
.clean-conf: ${CLEAN_SUBPROJECTS}
	${RM} -r ${CND_BUILDDIR}/${CND_CONF}
	${RM} ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_9_c_characters_and_strings.exe

# Subprojects
.clean-subprojects:

# Enable dependency checking
.dep.inc: .depcheck-impl

include .dep.inc
