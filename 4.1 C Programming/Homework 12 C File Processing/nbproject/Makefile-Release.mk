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
CND_CONF=Release
CND_DISTDIR=dist
CND_BUILDDIR=build

# Include project Makefile
include Makefile

# Object Directory
OBJECTDIR=${CND_BUILDDIR}/${CND_CONF}/${CND_PLATFORM}

# Object Files
OBJECTFILES= \
	${OBJECTDIR}/Problem\ 1.\ Print\ File\ Contents.o \
	${OBJECTDIR}/Problem\ 2.\ Odd\ Lines.o \
	${OBJECTDIR}/Problem\ 3.\ Line\ Numbers.o \
	${OBJECTDIR}/Problem\ 4.\ Copy\ Binary\ File.o \
	${OBJECTDIR}/Problem\ 5\ Slicing\ FIles.o \
	${OBJECTDIR}/Problem\ 6.\ Fix\ Subtitles.o


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
	"${MAKE}"  -f nbproject/Makefile-${CND_CONF}.mk ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_12_c_file_processing.exe

${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_12_c_file_processing.exe: ${OBJECTFILES}
	${MKDIR} -p ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}
	${LINK.c} -o ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_12_c_file_processing ${OBJECTFILES} ${LDLIBSOPTIONS}

.NO_PARALLEL:${OBJECTDIR}/Problem\ 1.\ Print\ File\ Contents.o
${OBJECTDIR}/Problem\ 1.\ Print\ File\ Contents.o: Problem\ 1.\ Print\ File\ Contents.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -O2 -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 1.\ Print\ File\ Contents.o Problem\ 1.\ Print\ File\ Contents.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 2.\ Odd\ Lines.o
${OBJECTDIR}/Problem\ 2.\ Odd\ Lines.o: Problem\ 2.\ Odd\ Lines.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -O2 -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 2.\ Odd\ Lines.o Problem\ 2.\ Odd\ Lines.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 3.\ Line\ Numbers.o
${OBJECTDIR}/Problem\ 3.\ Line\ Numbers.o: Problem\ 3.\ Line\ Numbers.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -O2 -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 3.\ Line\ Numbers.o Problem\ 3.\ Line\ Numbers.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 4.\ Copy\ Binary\ File.o
${OBJECTDIR}/Problem\ 4.\ Copy\ Binary\ File.o: Problem\ 4.\ Copy\ Binary\ File.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -O2 -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 4.\ Copy\ Binary\ File.o Problem\ 4.\ Copy\ Binary\ File.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 5\ Slicing\ FIles.o
${OBJECTDIR}/Problem\ 5\ Slicing\ FIles.o: Problem\ 5\ Slicing\ FIles.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -O2 -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 5\ Slicing\ FIles.o Problem\ 5\ Slicing\ FIles.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 6.\ Fix\ Subtitles.o
${OBJECTDIR}/Problem\ 6.\ Fix\ Subtitles.o: Problem\ 6.\ Fix\ Subtitles.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -O2 -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 6.\ Fix\ Subtitles.o Problem\ 6.\ Fix\ Subtitles.c

# Subprojects
.build-subprojects:

# Clean Targets
.clean-conf: ${CLEAN_SUBPROJECTS}
	${RM} -r ${CND_BUILDDIR}/${CND_CONF}
	${RM} ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_12_c_file_processing.exe

# Subprojects
.clean-subprojects:

# Enable dependency checking
.dep.inc: .depcheck-impl

include .dep.inc
