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
	${OBJECTDIR}/Bitwise\ Extract\ Bit\ #3.o \
	${OBJECTDIR}/Problem\ 1.\ First\ Bit.o \
	${OBJECTDIR}/Problem\ 2.\ Extract\ Bit\ from\ Integer.o \
	${OBJECTDIR}/Problem\ 3.\ Check\ a\ Bit\ at\ Given\ Position.o \
	${OBJECTDIR}/Problem\ 4.\ Bit\ Destroyer.o \
	${OBJECTDIR}/Problem\ 5.\ Modify\ a\ Bit\ at\ Given\ Position.o \
	${OBJECTDIR}/Problem\ 6.\ Bits\ Exchange.o \
	${OBJECTDIR}/Problem\ 7.\ Bits\ Exchange\ \(Advanced\).o


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
	"${MAKE}"  -f nbproject/Makefile-${CND_CONF}.mk ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_11_c_bit_manipulation.exe

${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_11_c_bit_manipulation.exe: ${OBJECTFILES}
	${MKDIR} -p ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}
	${LINK.c} -o ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_11_c_bit_manipulation ${OBJECTFILES} ${LDLIBSOPTIONS}

.NO_PARALLEL:${OBJECTDIR}/Bitwise\ Extract\ Bit\ #3.o
${OBJECTDIR}/Bitwise\ Extract\ Bit\ #3.o: Bitwise\ Extract\ Bit\ #3.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Bitwise\ Extract\ Bit\ #3.o Bitwise\ Extract\ Bit\ #3.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 1.\ First\ Bit.o
${OBJECTDIR}/Problem\ 1.\ First\ Bit.o: Problem\ 1.\ First\ Bit.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 1.\ First\ Bit.o Problem\ 1.\ First\ Bit.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 2.\ Extract\ Bit\ from\ Integer.o
${OBJECTDIR}/Problem\ 2.\ Extract\ Bit\ from\ Integer.o: Problem\ 2.\ Extract\ Bit\ from\ Integer.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 2.\ Extract\ Bit\ from\ Integer.o Problem\ 2.\ Extract\ Bit\ from\ Integer.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 3.\ Check\ a\ Bit\ at\ Given\ Position.o
${OBJECTDIR}/Problem\ 3.\ Check\ a\ Bit\ at\ Given\ Position.o: Problem\ 3.\ Check\ a\ Bit\ at\ Given\ Position.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 3.\ Check\ a\ Bit\ at\ Given\ Position.o Problem\ 3.\ Check\ a\ Bit\ at\ Given\ Position.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 4.\ Bit\ Destroyer.o
${OBJECTDIR}/Problem\ 4.\ Bit\ Destroyer.o: Problem\ 4.\ Bit\ Destroyer.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 4.\ Bit\ Destroyer.o Problem\ 4.\ Bit\ Destroyer.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 5.\ Modify\ a\ Bit\ at\ Given\ Position.o
${OBJECTDIR}/Problem\ 5.\ Modify\ a\ Bit\ at\ Given\ Position.o: Problem\ 5.\ Modify\ a\ Bit\ at\ Given\ Position.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 5.\ Modify\ a\ Bit\ at\ Given\ Position.o Problem\ 5.\ Modify\ a\ Bit\ at\ Given\ Position.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 6.\ Bits\ Exchange.o
${OBJECTDIR}/Problem\ 6.\ Bits\ Exchange.o: Problem\ 6.\ Bits\ Exchange.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 6.\ Bits\ Exchange.o Problem\ 6.\ Bits\ Exchange.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 7.\ Bits\ Exchange\ \(Advanced\).o
${OBJECTDIR}/Problem\ 7.\ Bits\ Exchange\ \(Advanced\).o: Problem\ 7.\ Bits\ Exchange\ \(Advanced\).c 
	${MKDIR} -p ${OBJECTDIR} \(Advanced
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 7.\ Bits\ Exchange\ \(Advanced\).o Problem\ 7.\ Bits\ Exchange\ \(Advanced\).c

# Subprojects
.build-subprojects:

# Clean Targets
.clean-conf: ${CLEAN_SUBPROJECTS}
	${RM} -r ${CND_BUILDDIR}/${CND_CONF}
	${RM} ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_11_c_bit_manipulation.exe

# Subprojects
.clean-subprojects:

# Enable dependency checking
.dep.inc: .depcheck-impl

include .dep.inc
