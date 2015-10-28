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
	${OBJECTDIR}/Problem\ 1.\ Bigger\ Number.o \
	${OBJECTDIR}/Problem\ 2.\ Last\ Digit\ of\ Number.o \
	${OBJECTDIR}/Problem\ 3.\ Last\ Occurrence\ of\ Character.o \
	${OBJECTDIR}/Problem\ 4.\ Reverse\ Number.o \
	${OBJECTDIR}/Problem\ 5.\ Array\ Manipulation.o \
	${OBJECTDIR}/Problem\ 5.1\ Array\ Manipulation.o \
	${OBJECTDIR}/Problem\ 6.\ First\ Larger\ Than\ Neighbours.o \
	${OBJECTDIR}/Problem\ 7.\ Recursive\ String\ Reverse.o


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
	"${MAKE}"  -f nbproject/Makefile-${CND_CONF}.mk ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_7_c_functions.exe

${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_7_c_functions.exe: ${OBJECTFILES}
	${MKDIR} -p ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}
	${LINK.c} -o ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_7_c_functions ${OBJECTFILES} ${LDLIBSOPTIONS}

.NO_PARALLEL:${OBJECTDIR}/Problem\ 1.\ Bigger\ Number.o
${OBJECTDIR}/Problem\ 1.\ Bigger\ Number.o: Problem\ 1.\ Bigger\ Number.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 1.\ Bigger\ Number.o Problem\ 1.\ Bigger\ Number.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 2.\ Last\ Digit\ of\ Number.o
${OBJECTDIR}/Problem\ 2.\ Last\ Digit\ of\ Number.o: Problem\ 2.\ Last\ Digit\ of\ Number.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 2.\ Last\ Digit\ of\ Number.o Problem\ 2.\ Last\ Digit\ of\ Number.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 3.\ Last\ Occurrence\ of\ Character.o
${OBJECTDIR}/Problem\ 3.\ Last\ Occurrence\ of\ Character.o: Problem\ 3.\ Last\ Occurrence\ of\ Character.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 3.\ Last\ Occurrence\ of\ Character.o Problem\ 3.\ Last\ Occurrence\ of\ Character.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 4.\ Reverse\ Number.o
${OBJECTDIR}/Problem\ 4.\ Reverse\ Number.o: Problem\ 4.\ Reverse\ Number.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 4.\ Reverse\ Number.o Problem\ 4.\ Reverse\ Number.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 5.\ Array\ Manipulation.o
${OBJECTDIR}/Problem\ 5.\ Array\ Manipulation.o: Problem\ 5.\ Array\ Manipulation.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 5.\ Array\ Manipulation.o Problem\ 5.\ Array\ Manipulation.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 5.1\ Array\ Manipulation.o
${OBJECTDIR}/Problem\ 5.1\ Array\ Manipulation.o: Problem\ 5.1\ Array\ Manipulation.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 5.1\ Array\ Manipulation.o Problem\ 5.1\ Array\ Manipulation.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 6.\ First\ Larger\ Than\ Neighbours.o
${OBJECTDIR}/Problem\ 6.\ First\ Larger\ Than\ Neighbours.o: Problem\ 6.\ First\ Larger\ Than\ Neighbours.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 6.\ First\ Larger\ Than\ Neighbours.o Problem\ 6.\ First\ Larger\ Than\ Neighbours.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 7.\ Recursive\ String\ Reverse.o
${OBJECTDIR}/Problem\ 7.\ Recursive\ String\ Reverse.o: Problem\ 7.\ Recursive\ String\ Reverse.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 7.\ Recursive\ String\ Reverse.o Problem\ 7.\ Recursive\ String\ Reverse.c

# Subprojects
.build-subprojects:

# Clean Targets
.clean-conf: ${CLEAN_SUBPROJECTS}
	${RM} -r ${CND_BUILDDIR}/${CND_CONF}
	${RM} ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_7_c_functions.exe

# Subprojects
.clean-subprojects:

# Enable dependency checking
.dep.inc: .depcheck-impl

include .dep.inc
